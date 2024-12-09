using System.Net;
using System.Web.Mvc;
using CHBHTH.Areas.Admin.Repositories;
using CHBHTH.Models;
using CHBHTH.Repositories;

namespace CHBHTH.Areas.Admin.Controllers
{
	public class PhanQuyensController : Controller
	{
		private readonly IPhanQuyenRepository _phanQuyenRepository;

		public PhanQuyensController(IPhanQuyenRepository phanQuyenRepository)
		{
			_phanQuyenRepository = phanQuyenRepository;
		}

		// GET: PhanQuyens
		public ActionResult Index()
		{
			var u = Session["use"] as CHBHTH.Models.TaiKhoan;
			if (u.PhanQuyen.IDQuyen == 1)
			{
				return View(_phanQuyenRepository.GetAll());
			}
			return RedirectPermanent("~/Admin/Home");
		}

		// GET: PhanQuyens/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PhanQuyen phanQuyen = _phanQuyenRepository.GetById(id.Value);
			if (phanQuyen == null)
			{
				return HttpNotFound();
			}
			return View(phanQuyen);
		}

		// GET: PhanQuyens/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PhanQuyens/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "IDQuyen,TenQuyen")] PhanQuyen phanQuyen)
		{
			if (ModelState.IsValid)
			{
				_phanQuyenRepository.Add(phanQuyen);
				_phanQuyenRepository.Save();
				return RedirectToAction("Index");
			}
			return View(phanQuyen);
		}

		// GET: PhanQuyens/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PhanQuyen phanQuyen = _phanQuyenRepository.GetById(id.Value);
			if (phanQuyen == null)
			{
				return HttpNotFound();
			}
			return View(phanQuyen);
		}

		// POST: PhanQuyens/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "IDQuyen,TenQuyen")] PhanQuyen phanQuyen)
		{
			if (ModelState.IsValid)
			{
				_phanQuyenRepository.Update(phanQuyen);
				_phanQuyenRepository.Save();
				return RedirectToAction("Index");
			}
			return View(phanQuyen);
		}

		// GET: PhanQuyens/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PhanQuyen phanQuyen = _phanQuyenRepository.GetById(id.Value);
			if (phanQuyen == null)
			{
				return HttpNotFound();
			}
			return View(phanQuyen);
		}

		// POST: PhanQuyens/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_phanQuyenRepository.Delete(id);
			_phanQuyenRepository.Save();
			return RedirectToAction("Index");
		}

		//protected override void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		_phanQuyenRepository = null;
		//	}
		//	base.Dispose(disposing);
		//}
	}
}
