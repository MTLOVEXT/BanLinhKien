namespace CHBHTH.Areas.Admin.Controllers
{
	using CHBHTH.Areas.Admin.Repositories;
	using CHBHTH.Models;
	using System.Net;
	using System.Web.Mvc;

	public class TinTucsController : Controller
	{
		private readonly ITinTucRepositoryAdmin _tinTucRepository;

		public TinTucsController(ITinTucRepositoryAdmin tinTucRepository)
		{
			_tinTucRepository = tinTucRepository;
		}

		// GET: TinTucs
		public ActionResult Index()
		{
			var u = Session["use"] as CHBHTH.Models.TaiKhoan;
			if (u.PhanQuyen.IDQuyen == 1 || u.PhanQuyen.IDQuyen == 3)
			{
				return View(_tinTucRepository.GetAll());
			}
			return RedirectPermanent("~/Home/Index");
		}

		// GET: TinTucs/Details/5
		public ActionResult Details(int? id)
		{
			var u = Session["use"] as CHBHTH.Models.TaiKhoan;
			if (u.PhanQuyen.TenQuyen == "Adminstrator")
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				TinTuc tinTuc = _tinTucRepository.GetById(id.Value);
				if (tinTuc == null)
				{
					return HttpNotFound();
				}
				return View(tinTuc);
			}
			return RedirectPermanent("~/Home/Index");
		}

		// GET: TinTucs/Create
		public ActionResult Create()
		{
			var u = Session["use"] as CHBHTH.Models.TaiKhoan;
			if (u.PhanQuyen.TenQuyen == "Adminstrator")
			{
				return View();
			}
			return RedirectPermanent("~/Home/Index");
		}

		// POST: TinTucs/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create([Bind(Include = "MaTT,TieuDe,NoiDung")] TinTuc tinTuc)
		{
			if (ModelState.IsValid)
			{
				_tinTucRepository.Add(tinTuc);
				_tinTucRepository.Save();
				return RedirectToAction("Index");
			}

			return View(tinTuc);
		}

		// GET: TinTucs/Edit/5
		public ActionResult Edit(int? id)
		{
			var u = Session["use"] as CHBHTH.Models.TaiKhoan;
			if (u.PhanQuyen.TenQuyen == "Adminstrator")
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				TinTuc tinTuc = _tinTucRepository.GetById(id.Value);
				if (tinTuc == null)
				{
					return HttpNotFound();
				}
				return View(tinTuc);
			}
			return RedirectPermanent("~/Home/Index");
		}

		// POST: TinTucs/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit([Bind(Include = "MaTT,TieuDe,NoiDung")] TinTuc tinTuc)
		{
			if (ModelState.IsValid)
			{
				_tinTucRepository.Update(tinTuc);
				_tinTucRepository.Save();
				return RedirectToAction("Index");
			}
			return View(tinTuc);
		}

		// GET: TinTucs/Delete/5
		public ActionResult Delete(int? id)
		{
			var u = Session["use"] as CHBHTH.Models.TaiKhoan;
			if (u.PhanQuyen.TenQuyen == "Adminstrator")
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				TinTuc tinTuc = _tinTucRepository.GetById(id.Value);
				if (tinTuc == null)
				{
					return HttpNotFound();
				}
				return View(tinTuc);
			}
			return RedirectPermanent("~/Home/Index");
		}

		// POST: TinTucs/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_tinTucRepository.Delete(id);
			_tinTucRepository.Save();
			return RedirectToAction("Index");
		}
	}
}
