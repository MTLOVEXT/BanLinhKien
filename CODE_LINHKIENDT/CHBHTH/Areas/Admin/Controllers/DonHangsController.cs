using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CHBHTH.Areas.Admin.Repositories;
using CHBHTH.Models;
using CHBHTH.Repositories;

namespace CHBHTH.Areas.Admin.Controllers
{
	public class DonHangsController : Controller
	{
		private readonly IDonHangRepositoryAdmin _donHangRepository;
		private readonly IChiTietDonHangRepositoryAdmin _chiTietDonHangRepository;


		public DonHangsController(IDonHangRepositoryAdmin donHangRepository,IChiTietDonHangRepositoryAdmin chiTietDonHangRepositoryAdmin)
		{
			_donHangRepository = donHangRepository;
			_chiTietDonHangRepository = chiTietDonHangRepositoryAdmin;
		}

		// GET: DonHangs
		public ActionResult Index()
		{
			var donHangs = _donHangRepository.GetAllDonHangs();
			var u = Session["use"] as TaiKhoan;
			if (u.PhanQuyen.IDQuyen == 1 || u.PhanQuyen.IDQuyen == 3)
			{
				return View(donHangs);
			}
			return RedirectPermanent("~/Home/Index");
		}

		// GET: DonHangs/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var donHang = _donHangRepository.GetDonHangById(id.Value);
			if (donHang == null)
			{
				return HttpNotFound("Không tìm thấy đơn hàng.");
			}

			return View(donHang);
		}

		// GET: DonHangs/Create
		public ActionResult Create()
		{
			ViewBag.MaNguoiDung = new SelectList(_donHangRepository.GetAllDonHangs(), "MaNguoiDung", "HoTen");
			return View();
		}

		// POST: DonHangs/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Madon,NgayDat,TinhTrang,ThanhToan,DiaChiNhanHang,MaNguoiDung,TongTien")] DonHang donHang)
		{
			if (ModelState.IsValid)
			{
				_donHangRepository.AddDonHang(donHang);
				_donHangRepository.Save();
				return RedirectToAction("Index");
			}

			ViewBag.MaNguoiDung = new SelectList(_donHangRepository.GetAllDonHangs(), "MaNguoiDung", "HoTen", donHang.MaNguoiDung);
			return View(donHang);
		}

		// GET: DonHangs/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var donHang = _donHangRepository.GetDonHangById(id.Value);

			if (donHang == null)
			{
				return HttpNotFound();
			}

			// Lấy danh sách tài khoản để hiển thị trong DropDownList
			var taiKhoans = _donHangRepository.GetAllTaiKhoans(); // Giả định có phương thức này
			ViewBag.MaNguoiDung = new SelectList(taiKhoans, "MaNguoiDung", "HoTen", donHang.MaNguoiDung);

			return View(donHang);
		}

		// POST: DonHangs/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(DonHang donHang)
		{
			if (ModelState.IsValid)
			{
				_donHangRepository.UpdateDonHang(donHang);
				_donHangRepository.Save();
				return RedirectToAction("Index");
			}

			// Lấy lại danh sách tài khoản nếu ModelState không hợp lệ
			var taiKhoans = _donHangRepository.GetAllTaiKhoans();
			ViewBag.MaNguoiDung = new SelectList(taiKhoans, "MaNguoiDung", "HoTen", donHang.MaNguoiDung);

			return View(donHang);
		}

		// GET: DonHangs/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var donHang = _donHangRepository.GetDonHangById(id.Value);
			if (donHang == null)
			{
				return HttpNotFound();
			}
			return View(donHang);
		}

		// POST: DonHangs/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var donHang = _donHangRepository.GetDonHangById(id);
			if (donHang == null)
			{
				return HttpNotFound();
			}

			// Xóa chi tiết đơn hàng trước khi xóa đơn hàng chính
			_chiTietDonHangRepository.DeleteChiTietDonHangsByOrderId(id); // Giả sử có phương thức xóa chi tiết đơn hàng
			_donHangRepository.DeleteDonHang(id);
			_donHangRepository.Save();

			TempData["Message"] = "Đơn hàng đã được xóa thành công!";
			return RedirectToAction("Index");
		}


		// Xacnhan Action
		public ActionResult Xacnhan(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var donHang = _donHangRepository.GetDonHangById(id.Value);
			if (donHang == null)
			{
				return HttpNotFound("Không tìm thấy đơn hàng.");
			}

			// Cập nhật trạng thái TinhTrang
			donHang.TinhTrang = 1; // Đã xác nhận

			// Lưu thay đổi
			_donHangRepository.UpdateDonHang(donHang);
			_donHangRepository.Save();

			TempData["Message"] = "Đơn hàng đã được xác nhận!";
			return RedirectToAction("Details", new { id = id });
		}



		[ChildActionOnly]
		public ActionResult CTDetails(int id)
		{
			var chiTietDonHangs = _chiTietDonHangRepository.GetByOrderId(id);

			if (chiTietDonHangs == null || !chiTietDonHangs.Any())
			{
				return HttpNotFound("Không tìm thấy chi tiết đơn hàng.");
			}

			return PartialView("CTDetails", chiTietDonHangs);
		}
	}
}
