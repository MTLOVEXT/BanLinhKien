using CHBHTH.Areas.Admin.Repositories;
using CHBHTH.Models;
using System.Net;
using System.Web.Mvc;

namespace CHBHTH.Areas.Admin.Controllers
{
	public class NhaCungCapsController : Controller
	{
		private readonly INhaCungCapRepository _nhaCungCapRepository;

		// Inject the NhaCungCapRepository into the controller
		public NhaCungCapsController(INhaCungCapRepository nhaCungCapRepository)
		{
			_nhaCungCapRepository = nhaCungCapRepository;
		}

		// GET: NhaCungCaps
		public ActionResult Index()
		{
			var u = Session["use"] as CHBHTH.Models.TaiKhoan;
			if (u.PhanQuyen.IDQuyen == 1)
			{
				var nhaCungCaps = _nhaCungCapRepository.GetAll();
				return View(nhaCungCaps);
			}
			return RedirectPermanent("~/Home/Index");
		}

		// GET: NhaCungCaps/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NhaCungCap nhaCungCap = _nhaCungCapRepository.GetById(id.Value);
			if (nhaCungCap == null)
			{
				return HttpNotFound();
			}
			return View(nhaCungCap);
		}

		// GET: NhaCungCaps/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: NhaCungCaps/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "MaNCC,TenNCC")] NhaCungCap nhaCungCap)
		{
			if (ModelState.IsValid)
			{
				_nhaCungCapRepository.Add(nhaCungCap);
				_nhaCungCapRepository.Save();
				return RedirectToAction("Index");
			}

			return View(nhaCungCap);
		}

		// GET: NhaCungCaps/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NhaCungCap nhaCungCap = _nhaCungCapRepository.GetById(id.Value);
			if (nhaCungCap == null)
			{
				return HttpNotFound();
			}
			return View(nhaCungCap);
		}

		// POST: NhaCungCaps/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "MaNCC,TenNCC")] NhaCungCap nhaCungCap)
		{
			if (ModelState.IsValid)
			{
				_nhaCungCapRepository.Update(nhaCungCap);
				_nhaCungCapRepository.Save();
				return RedirectToAction("Index");
			}
			return View(nhaCungCap);
		}

		// GET: NhaCungCaps/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NhaCungCap nhaCungCap = _nhaCungCapRepository.GetById(id.Value);
			if (nhaCungCap == null)
			{
				return HttpNotFound();
			}
			return View(nhaCungCap);
		}

		// POST: NhaCungCaps/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_nhaCungCapRepository.Delete(id);
			_nhaCungCapRepository.Save();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Dispose of any resources that need to be disposed of
			}
			base.Dispose(disposing);
		}
	}
}
