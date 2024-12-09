using CHBHTH.Models;
using CHBHTH.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace CHBHTH.Repositories
{
	public class VnpayService : IVNPayService
	{
		private readonly string _vnp_Url = ConfigurationManager.AppSettings["VNP_Url"];
        private readonly string _vnp_TmnCode = ConfigurationManager.AppSettings["VNP_TmnCode"];
        private readonly string _vnp_HashSecret = ConfigurationManager.AppSettings["VNP_HashSecret"];

        public string CreatePaymentUrl(DonHang donHang, string returnUrl)
		{
			decimal tongTien = donHang.TongTien ?? 0;
			int vnpAmount = (int)(tongTien * 100); // Tính số tiền theo đơn vị nhỏ nhất (VND)

			string vnpTxnRef = donHang.MaDon.ToString();  // Mã giao dịch phải duy nhất

			string vnpOrderInfo = "Thanh toán đơn hàng #" + donHang.MaDon;
			//string vnpOrderInfo = Uri.EscapeDataString(orderInfo); // Mã hóa URL cho vnp_OrderInfo

			string vnpCreateDate = DateTime.Now.ToString("yyyyMMddHHmmss");

			// Lấy thông tin múi giờ từ TimeZoneInfo
			TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
			DateTime currentDateTimeInTimeZone = TimeZoneInfo.ConvertTime(DateTime.Now, timeZone);
			string vnpTimeZone = timeZone.Id; // Lấy tên múi giờ

			string vnp_IpAddr = GetLocalIpAddress();

			String orderType = "other";


			var vnpay = new VnPayLibrary();
			vnpay.AddRequestData("vnp_Version", "2.1.0");
			vnpay.AddRequestData("vnp_Command", "pay");
			vnpay.AddRequestData("vnp_TmnCode", _vnp_TmnCode);
			vnpay.AddRequestData("vnp_Amount", vnpAmount.ToString());
			vnpay.AddRequestData("vnp_CurrCode", "VND");
			vnpay.AddRequestData("vnp_TxnRef", vnpTxnRef);
			vnpay.AddRequestData("vnp_OrderInfo", vnpOrderInfo);
			vnpay.AddRequestData("vnp_Locale", "vn");
			vnpay.AddRequestData("vnp_ReturnUrl", returnUrl);
			vnpay.AddRequestData("vnp_CreateDate", vnpCreateDate);
			vnpay.AddRequestData("vnp_TimeZone", vnpTimeZone); // Thêm múi giờ vào yêu cầu
			vnpay.AddRequestData("vnp_IpAddr", vnp_IpAddr); // Thêm địa chỉ IP vào yêu cầu
			vnpay.AddRequestData("vnp_OrderType", orderType);


			var paymentUrl = vnpay.CreateRequestUrl(_vnp_Url, _vnp_HashSecret);
			return paymentUrl;
		}

		public bool ValidatePayment(string vnp_SecureHash, out string responseMessage)
		{
			var vnpay = new VnPayLibrary();
			var isValid = vnpay.ValidateSignature(vnp_SecureHash, _vnp_HashSecret);
			responseMessage = isValid ? "Giao dịch hợp lệ." : "Giao dịch không hợp lệ.";
			return isValid;
		}

		public string GetLocalIpAddress()
		{
			// Lấy danh sách tất cả các địa chỉ IP của máy tính
			var host = Dns.GetHostEntry(Dns.GetHostName());

			// Lọc ra địa chỉ IPv4 (không lấy IPv6)
			var ipAddress = host.AddressList
								.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

			return ipAddress?.ToString();  // Trả về địa chỉ IP dưới dạng chuỗi, hoặc null nếu không tìm thấy
		}
	}
}