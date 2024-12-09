using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace CHBHTH.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        // GET: Admin/Home
        public ActionResult Index()
        {
            var u = Session["use"] as CHBHTH.Models.TaiKhoan;
            //Kiểm tra nếu tên quyền Administrator mới được truy cập trang admin
            if(u.PhanQuyen.IDQuyen == 1 || u.PhanQuyen.IDQuyen == 3)
            {
                return View();
            }

            return RedirectPermanent("~/Home/Index");
        }
    }
}