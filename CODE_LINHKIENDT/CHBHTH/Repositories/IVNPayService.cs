using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CHBHTH.Repositories
{
	public interface IVNPayService
	{
		string CreatePaymentUrl(DonHang donHang, string returnUrl);
		bool ValidatePayment(string vnp_SecureHash, out string responseMessage);
	}
}
