using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHBHTH.Controllers
{
    public class danhmucController : BaseDanhMucController
	{
        // GET: Danhmuc
        QLbanhang db = new QLbanhang();

		// Constructor nhận repository qua Dependency Injection
		public danhmucController(IDanhMucRepository danhMucRepository)
			: base(danhMucRepository)
		{
		}
		// GET: Danhmuc
		public ActionResult danhmucpartial()
        {
			//var danhmuc = db.LoaiHangs.ToList();
			//return PartialView(danhmuc);

			var danhmuc = GetLoaiHangsByCondition(n => n.TenLoai != "Thùng rác").Take(6).ToList();
			return PartialView(danhmuc);
        }

    }
}