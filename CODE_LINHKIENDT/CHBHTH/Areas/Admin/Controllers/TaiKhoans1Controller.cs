using System.Net;
using System.Web.Mvc;
using CHBHTH.Areas.Admin.Repositories;
using CHBHTH.Models;
using CHBHTH.Repositories;

namespace CHBHTH.Areas.Admin.Controllers
{
	public class TaiKhoans1Controller : Controller
	{
		private readonly ITaiKhoanRepositoryAdmin _taiKhoanRepository;
		private readonly IPhanQuyenRepository _phanQuyenRepository;


		// Inject Repository vào Controller
		public TaiKhoans1Controller(ITaiKhoanRepositoryAdmin taiKhoanRepository, IPhanQuyenRepository phanQuyenRepository)
		{
			_taiKhoanRepository = taiKhoanRepository;
			_phanQuyenRepository = phanQuyenRepository;

		}

		// GET: TaiKhoans
		public ActionResult Index()
		{
			var taiKhoans = _taiKhoanRepository.GetAllTaiKhoans();
			var u = Session["use"] as CHBHTH.Models.TaiKhoan;
			if (u == null || u.PhanQuyen.IDQuyen != 1)
			{
				return RedirectPermanent("~/Admin/Home");
			}
			return View(taiKhoans);

		}

		// GET: TaiKhoans/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			TaiKhoan taiKhoan = _taiKhoanRepository.GetTaiKhoanById(id.Value);
			if (taiKhoan == null)
			{
				return HttpNotFound();
			}
			return View(taiKhoan);
		}

		// GET: TaiKhoans/Create
		public ActionResult Create()
		{
			ViewBag.IDQuyen = new SelectList(_phanQuyenRepository.GetAll(), "IDQuyen", "TenQuyen");
			return View();
		}

		// POST: TaiKhoans/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "MaNguoiDung,HoTen,Email,Dienthoai,Matkhau,IDQuyen,Diachi")] TaiKhoan taiKhoan)
		{
			if (ModelState.IsValid)
			{
				_taiKhoanRepository.AddTaiKhoan(taiKhoan);
				_taiKhoanRepository.Save();
				return RedirectToAction("Index");
			}

			ViewBag.IDQuyen = new SelectList(_phanQuyenRepository.GetAll(), "IDQuyen", "TenQuyen");
			return View(taiKhoan);
		}

		// GET: TaiKhoans/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			TaiKhoan taiKhoan = _taiKhoanRepository.GetTaiKhoanById(id.Value);
			if (taiKhoan == null)
			{
				return HttpNotFound();
			}

			// Assuming you have a method to get all PhanQuyen
			ViewBag.IDQuyen = new SelectList(_phanQuyenRepository.GetAll(), "IDQuyen", "TenQuyen", taiKhoan.IDQuyen);
			return View(taiKhoan);
		}

		// POST: TaiKhoans/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "MaNguoiDung,HoTen,Email,Dienthoai,Matkhau,IDQuyen,Diachi")] TaiKhoan taiKhoan)
		{
			if (ModelState.IsValid)
			{
				_taiKhoanRepository.UpdateTaiKhoan(taiKhoan);
				_taiKhoanRepository.Save();
				return RedirectToAction("Index");
			}
			ViewBag.IDQuyen = new SelectList(_taiKhoanRepository.GetAllTaiKhoans(), "IDQuyen", "TenQuyen", taiKhoan.IDQuyen);
			return View(taiKhoan);
		}

		// GET: TaiKhoans/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			TaiKhoan taiKhoan = _taiKhoanRepository.GetTaiKhoanById(id.Value);
			if (taiKhoan == null)
			{
				return HttpNotFound();
			}
			return View(taiKhoan);
		}

		// POST: TaiKhoans/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_taiKhoanRepository.DeleteTaiKhoan(id);
			_taiKhoanRepository.Save();
			return RedirectToAction("Index");
		}
	}
}
