using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CHBHTH.Repositories;

namespace CHBHTH.Controllers
{
    public class sanphamController : Controller
    {
        private QLbanhang db = new QLbanhang();
		private readonly ISanPhamRepository _sanPhamRepository;

		// Constructor nhận dependency
		public sanphamController(ISanPhamRepository sanPhamRepository)
		{
			_sanPhamRepository = sanPhamRepository;
		}
		// GET: sanpham
		public ActionResult Index()
        {
			var sanPhams = _sanPhamRepository.GetAll();
			return View(sanPhams.ToList());
        }

        public ActionResult suapartial()
        {
            int maLoai = 1; // Mã Điện máy
            string tenLoaiHang = _sanPhamRepository.GetTenLoaiHang(maLoai); // Lấy tên loại hàng
            ViewBag.TenLoaiHang = tenLoaiHang; // Truyền vào ViewBag

            var ip = _sanPhamRepository.GetByLoaiHang(maLoai, 4);
            return PartialView(ip);
        }

        public ActionResult raupartial()
        {
            int maLoai = 5; // Mã điện thoại
            string tenLoaiHang = _sanPhamRepository.GetTenLoaiHang(maLoai); // Lấy tên loại hàng
            ViewBag.TenLoaiHang = tenLoaiHang; // Truyền vào ViewBag
            var ip = _sanPhamRepository.GetByLoaiHang(maLoai, 4);
			return PartialView(ip);
        }

        public ActionResult dauanpartial()  
        {
            int maLoai = 6; // Mã Hàng mới 
            string tenLoaiHang = _sanPhamRepository.GetTenLoaiHang(maLoai); // Lấy tên loại hàng
            ViewBag.TenLoaiHang = tenLoaiHang; // Truyền vào ViewBag
            var ip = _sanPhamRepository.GetByLoaiHang(maLoai, 4);
			return PartialView(ip);
        }

        public ActionResult xemchitiet(int Masp = 0)
        {
			var chitiet = _sanPhamRepository.GetById(Masp);
			if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }


        public ActionResult xemchitietdanhmuc(int MaLoai)
        {
			var ip = _sanPhamRepository.GetByLoaiHang(MaLoai);
			return PartialView(ip);

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