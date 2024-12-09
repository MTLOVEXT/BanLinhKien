using CHBHTH.Models;
using CHBHTH.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHBHTH.Controllers
{
    public class tintucController : Controller
    {
        private QLbanhang db = new QLbanhang();
		private readonly ITintucRepository _tinTucRepository;

		// Constructor nhận dependency
		public tintucController(ITintucRepository tinTucRepository)
		{
			_tinTucRepository = tinTucRepository;
		}
		// GET: tintuc

		public ActionResult Index()
        {
			var tintucs = _tinTucRepository.GetAll();
			return View(tintucs);
        }

        public ActionResult tintucpartital()
        {
			var ip = _tinTucRepository.GetTop(4);
			return PartialView(ip);
        }

        public ActionResult xemchitiettintuc(int MaTT = 0)
        {
			var chitiet = _tinTucRepository.GetById(MaTT);
			if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }
    }
}