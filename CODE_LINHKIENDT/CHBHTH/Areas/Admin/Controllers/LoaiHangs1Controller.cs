namespace CHBHTH.Areas.Admin.Controllers
{
	using CHBHTH.Areas.Admin.Repositories;
	using CHBHTH.Models;
	using System.Net;
	using System.Web.Mvc;

	public class LoaiHangs1Controller : Controller
	{
		private readonly ILoaiHangRepository _loaiHangRepository;

		public LoaiHangs1Controller(ILoaiHangRepository loaiHangRepository)
		{
			_loaiHangRepository = loaiHangRepository;
		}

		// GET: LoaiHangs
		public ActionResult Index()
		{
			var u = Session["use"] as CHBHTH.Models.TaiKhoan;
			if (u.PhanQuyen.IDQuyen == 1 || u.PhanQuyen.IDQuyen == 3)
			{
				return View(_loaiHangRepository.GetAll());
			}
			return RedirectPermanent("~/Admin/Home");
		}

		// GET: LoaiHangs/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			LoaiHang loaiHang = _loaiHangRepository.GetById(id.Value);
			if (loaiHang == null)
			{
				return HttpNotFound();
			}
			return View(loaiHang);
		}

		// GET: LoaiHangs/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: LoaiHangs/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "MaLoai,TenLoai")] LoaiHang loaiHang)
		{
			if (ModelState.IsValid)
			{
				_loaiHangRepository.Add(loaiHang);
				_loaiHangRepository.Save();
				return RedirectToAction("Index");
			}

			return View(loaiHang);
		}

		// GET: LoaiHangs/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			LoaiHang loaiHang = _loaiHangRepository.GetById(id.Value);
			if (loaiHang == null)
			{
				return HttpNotFound();
			}
			return View(loaiHang);
		}

		// POST: LoaiHangs/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "MaLoai,TenLoai")] LoaiHang loaiHang)
		{
			if (ModelState.IsValid)
			{
				_loaiHangRepository.Update(loaiHang);
				_loaiHangRepository.Save();
				return RedirectToAction("Index");
			}
			return View(loaiHang);
		}

		// GET: LoaiHangs/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			LoaiHang loaiHang = _loaiHangRepository.GetById(id.Value);
			if (loaiHang == null)
			{
				return HttpNotFound();
			}
			return View(loaiHang);
		}

		// POST: LoaiHangs/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_loaiHangRepository.Delete(id);
			_loaiHangRepository.Save();
			return RedirectToAction("Index");
		}
	}
}
