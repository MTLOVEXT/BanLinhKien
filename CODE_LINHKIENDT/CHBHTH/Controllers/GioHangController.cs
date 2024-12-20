﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CHBHTH.Models;
using CHBHTH.Repositories;
using CHBHTH.Service;

namespace CHBHTH.Controllers
{
	public class GioHangController : Controller
	{
		private readonly IGioHangRepository _gioHangRepository;
		private readonly IDonHangRepository _donHangRepository;
		private readonly ITaiKhoanRepository _taiKhoanRepository;
		private readonly ISanPhamRepository _sanPhamRepository;
		private readonly IVNPayService _vnpayService;


		private QLbanhang db = new QLbanhang();

		public GioHangController()
		{
			_gioHangRepository = new GioHangRepository();
			_donHangRepository = new DonHangRepository();
			_taiKhoanRepository = new TaiKhoanRepository();
			_sanPhamRepository = new SanPhamRepository(db);
			_vnpayService = new VnpayService();

		}

		private List<GioHang> LayGioHang()
		{
			return _gioHangRepository.LayGioHang(Session);
		}

		public ActionResult ThemGioHang(int iMasp, string strURL)
		{
			var sp = new QLbanhang().SanPhams.SingleOrDefault(n => n.MaSP == iMasp);
			if (sp == null)
			{
				return HttpNotFound("Sản phẩm không tồn tại.");
			}

			_gioHangRepository.ThemGioHang(iMasp, Session);
			return Redirect(strURL);
		}

		public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
		{
			if (!int.TryParse(f["txtSoLuong"], out int soLuongMoi) || soLuongMoi < 0)
			{
				return new HttpStatusCodeResult(400, "Số lượng không hợp lệ.");
			}

			bool gioHangConSanPham = _gioHangRepository.CapNhatGioHang(iMaSP, soLuongMoi, Session);

			if (!gioHangConSanPham)
			{
				return RedirectToAction("Index", "Home");
			}

			return RedirectToAction("GioHang");
		}

		public ActionResult XoaGioHang(int iMaSP)
		{
			_gioHangRepository.XoaGioHang(iMaSP, Session);
			return RedirectToAction("GioHang");
		}

		public ActionResult GioHang()
		{
			var gioHang = LayGioHang();
			if (!gioHang.Any())
			{
				ViewBag.Message = "Giỏ hàng của bạn hiện đang trống.";
			}
			return View(gioHang);
		}

		public ActionResult GioHangPartial()
		{
			ViewBag.TongSoLuong = _gioHangRepository.TongSoLuong(Session);
			ViewBag.TongTien = _gioHangRepository.TongTien(Session);
			return PartialView();
		}

		public ActionResult SuaGioHang()
		{
			if (Session["GioHang"] == null)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(LayGioHang());
		}

        public ActionResult ThanhToanDonHang()
        {
            // Lấy thông tin phương thức thanh toán và tài khoản
            ViewBag.MaTT = new SelectList(new[]
            {
        new { MaTT = 1, TenPT = "Thanh toán tiền mặt" },
        new { MaTT = 2, TenPT = "Thanh toán chuyển khoản" }
    }, "MaTT", "TenPT", 1);

            ViewBag.MaNguoiDung = new SelectList(
                _taiKhoanRepository.GetAllTaiKhoans(), "MaNguoiDung", "HoTen"
            );

            // Kiểm tra đăng nhập
            var user = _taiKhoanRepository.GetNguoiDungBySession(Session["use"]);
            if (user == null)
            {
                return RedirectToAction("DangNhap", "User");
            }

            // Lưu thông tin người dùng vào ViewBag
            ViewBag.TenNguoiDung = user.HoTen;
            ViewBag.EmailNguoiDung = user.Email;

            // Kiểm tra giỏ hàng
            var gioHang = _gioHangRepository.LayGioHang(Session);
            if (!gioHang.Any())
            {
                return RedirectToAction("Index", "Home");
            }

            // Kiểm tra số lượng sản phẩm
            var errors = new List<string>();
            foreach (var item in gioHang)
            {
                string message = _gioHangRepository.KiemTraSoLuongSanPham(item.iMasp, item.iSoLuong, Session);
                if (message != "Số lượng hợp lệ.")
                {
                    errors.Add(message); // Thêm lỗi vào danh sách
                }
            }

            // Nếu có lỗi, hiển thị lại View với thông báo lỗi
            if (errors.Any())
            {
                ViewBag.ErrorMessages = errors;
                return View("GioHang", gioHang); // Hiển thị lại giỏ hàng với thông báo lỗi
            }

            // Tính tổng tiền
            var tongTien = _gioHangRepository.TongTien(Session);
            ViewBag.TongTien = tongTien;

            // Lưu giỏ hàng vào TempData
            TempData["GioHang"] = gioHang;

            // Chuẩn bị đơn hàng để hiển thị trên view
            var donHang = new DonHang
            {
                MaNguoiDung = user.MaNguoiDung,
                NgayDat = DateTime.Now
            };

            return View(donHang);
        }


        [HttpPost]
		public ActionResult ThanhToanDonHang(DonHang donHang, FormCollection form)
		{
			try
			{
				// Lấy giỏ hàng từ TempData
				var gioHang = LayGioHang();
				if (gioHang == null || !gioHang.Any())
				{
					return RedirectToAction("Index", "Home");
				}

				var user = _taiKhoanRepository.GetNguoiDungBySession(Session["use"]);
				// Lấy thông tin đơn hàng từ form
				donHang.DiaChiNhanHang = form["DiaChiNhanHang"];
				donHang.ThanhToan = int.Parse(form["MaTT"]);
				donHang.TongTien = (decimal)_gioHangRepository.TongTien(Session);
				donHang.MaNguoiDung = user.MaNguoiDung;
				donHang.NgayDat = DateTime.Now;

				// Lưu đơn hàng
				_donHangRepository.SaveOrder(donHang);

				// Lưu chi tiết đơn hàng
				foreach (var item in gioHang)
				{
					var chiTietDonHang = new ChiTietDonHang
					{
						MaDon = donHang.MaDon,
						MaSP = item.iMasp,
						SoLuong = item.iSoLuong,
						DonGia = (decimal?)item.dDonGia,
					    ThanhTien = (decimal?)item.ThanhTien,
						PhuongThucThanhToan = donHang.ThanhToan
					};
					_donHangRepository.SaveOrderDetail(chiTietDonHang);

					// Trừ số lượng sản phẩm trong kho
					_sanPhamRepository.TruSoLuongSanPham(item.iMasp, item.iSoLuong);
				}

				// Xóa giỏ hàng sau khi đặt hàng
				_gioHangRepository.ClearCart(Session);
				// Chuyển hướng đến trang "Đặt hàng thành công"
				ViewBag.MaDonHang = donHang.MaDon;
				ViewBag.NgayDat = donHang.NgayDat ?? DateTime.Now;
				ViewBag.TongTien = donHang.TongTien ?? 0;
				ViewBag.DiaChiNhanHang = donHang.DiaChiNhanHang ?? "Không có địa chỉ nhận hàng";
				ViewBag.PhuongThucThanhToan = (form["MaTT"] == "1") ? "Thanh toán tiền mặt" : "Thanh toán chuyển khoản";

				return View("DatHangThanhCong");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "Lỗi khi đặt hàng: " + ex.Message);
				return View(donHang);
			}
		}


		public ActionResult DatHangThanhCong()
		{
			return View();
		}

		[HttpPost]
		public ActionResult ThanhToanVnpay(DonHang donHang)
		{
			try
			{
				var gioHang = _gioHangRepository.LayGioHang(Session);
				if (!gioHang.Any())
				{
					return RedirectToAction("GioHang");
				}
				var user = _taiKhoanRepository.GetNguoiDungBySession(Session["use"]);
				// Lưu thông tin đơn hàng vào DB
				donHang.MaNguoiDung = user.MaNguoiDung;
				donHang.NgayDat = DateTime.Now;
				donHang.TongTien = _gioHangRepository.TongTien(Session);
				donHang.ThanhToan = 2; // Phương thức thanh toán: VNPAY
				donHang.TinhTrang = 0;

				_donHangRepository.SaveOrder(donHang);
				// Lưu chi tiết đơn hàng
				foreach (var item in gioHang)
				{
					var chiTietDonHang = new ChiTietDonHang
					{
						MaDon = donHang.MaDon,
						MaSP = item.iMasp,
						SoLuong = item.iSoLuong,
						DonGia = (decimal)item.dDonGia,
						ThanhTien = (decimal)item.ThanhTien,
						PhuongThucThanhToan = donHang.ThanhToan
					};

					_donHangRepository.SaveOrderDetail(chiTietDonHang); // Lưu chi tiết đơn hàng vào DB

					// Trừ số lượng sản phẩm trong kho
					_sanPhamRepository.TruSoLuongSanPham(item.iMasp, item.iSoLuong);
				}

				// Lấy URL thanh toán từ VNPAY
				var returnUrl = Url.Action("KiemTraThanhToan", "GioHang", null, Request.Url.Scheme);
				var paymentUrl = _vnpayService.CreatePaymentUrl(donHang, returnUrl);

				return Redirect(paymentUrl);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", $"Lỗi khi thực hiện thanh toán: {ex.Message}");
				return View("ThanhToanDonHang", donHang);
			}
		}

		public ActionResult KiemTraThanhToan()
		{
			string vnp_SecureHash = Request.QueryString["vnp_SecureHash"];
			string vnp_ResponseCode = Request.QueryString["vnp_ResponseCode"];
			int maDon = int.Parse(Request.QueryString["vnp_TxnRef"]);

			if (_vnpayService.ValidatePayment(vnp_SecureHash, out string responseMessage))
			{
				if (vnp_ResponseCode == "00") // Giao dịch thành công
				{
					var donHang = _donHangRepository.GetDonHangById(maDon);
					donHang.TinhTrang = 1;
					_donHangRepository.UpdateOrder(donHang);
					_gioHangRepository.ClearCart(Session);
					ViewBag.Message = "Thanh toán thành công!";
				}
				else
				{
					ViewBag.Message = "Giao dịch không thành công.";
				}
			}
			else
			{
				ViewBag.Message = responseMessage;
			}

			return View("DatHangThanhCong");
		}
	}
}
