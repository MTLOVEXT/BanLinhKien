using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CHBHTH.Models;


namespace CHBHTH.Controllers
{
    public class DonhangsController : BaseDonHangController
	{
        private QLbanhang db = new QLbanhang();
		// Constructor nhận repository qua Dependency Injection
		public DonhangsController(IDonHangRepository donHangRepository)
			: base(donHangRepository)
		{
		}

		// GET: Donhangs
		// Hiển thị danh sách đơn hàng
		public ActionResult Index()
        {
			// Kiểm tra đăng nhập
			if (Session["use"] == null || Session["use"].ToString() == "")
			{
				return RedirectToAction("Dangnhap", "User");
			}

			TaiKhoan kh = (TaiKhoan)Session["use"];
			int maND = kh.MaNguoiDung;

			// Lấy danh sách đơn hàng của người dùng
			var donhangs = GetDonHangsForUser(maND);
			return View(donhangs.ToList());
        }

        // GET: Donhangs/Details/5
        //Hiển thị chi tiết đơn hàng
        public ActionResult Details(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			DonHang donhang = _donHangRepository.GetDonHangById(id.Value);
			if (donhang == null)
			{
				return HttpNotFound();
			}

			var chitiet = GetChiTietForDonHang(id.Value);
			return View(chitiet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
