namespace CHBHTH.Areas.Admin.Controllers
{
	using CHBHTH.Areas.Admin.Repositories;
	using CHBHTH.Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class ThongkesController : Controller
	{
		private readonly IThongKeRepository _thongKeRepository;

		// Constructor injection for repository
		public ThongkesController(IThongKeRepository thongKeRepository)
		{
			_thongKeRepository = thongKeRepository;
		}

		// GET: Thongkes
		public ActionResult Index(int? year)
		{
			var u = Session["use"] as CHBHTH.Models.TaiKhoan;
			if (u.PhanQuyen.IDQuyen == 1)
			{
				var dataThongke = _thongKeRepository.GetTopCustomers();
				var bestSellingProducts = _thongKeRepository.GetBestSellingProducts();
				var productsSoldInYear = year.HasValue ? _thongKeRepository.GetProductsSoldInYear(year.Value) : new List<SanPham>();

				ViewBag.BestSellingProducts = bestSellingProducts;
				ViewBag.ProductsSoldInYear = productsSoldInYear;
				ViewBag.SelectedYear = year ?? DateTime.Now.Year;

				return View(dataThongke);
			}
			return RedirectPermanent("~/Home/Index");
		}

	}
}
