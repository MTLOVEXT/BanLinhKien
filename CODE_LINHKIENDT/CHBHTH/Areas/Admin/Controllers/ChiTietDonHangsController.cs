using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using CHBHTH.Areas.Admin.Repositories;
using CHBHTH.Models;
using CHBHTH.Repositories;

namespace CHBHTH.Areas.Admin.Controllers
{
	public class ChiTietDonHangsController : Controller
	{
		private readonly IChiTietDonHangRepositoryAdmin _chiTietDonHangRepository;

		public ChiTietDonHangsController(IChiTietDonHangRepositoryAdmin chiTietDonHangRepository)
		{
			_chiTietDonHangRepository = chiTietDonHangRepository;
		}

		// GET: ChiTietDonHangs
		public ActionResult Index(int? id)
		{
			var chiTietDonHangs = _chiTietDonHangRepository.GetAll();
			var u = Session["use"] as CHBHTH.Models.TaiKhoan;
			if (u.PhanQuyen.IDQuyen == 1 || u.PhanQuyen.IDQuyen == 3)
			{
				return View(chiTietDonHangs);
			}
			return RedirectPermanent("~/Home/Index");
		}

		// GET: ChiTietDonHangs/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var chiTietDonHang = _chiTietDonHangRepository.GetById(id.Value);
			if (chiTietDonHang == null)
			{
				return HttpNotFound();
			}
			return View(chiTietDonHang);
		}

		// GET: ChiTietDonHangs/Create
		public ActionResult Create()
		{
			ViewBag.MaDon = new SelectList(_chiTietDonHangRepository.GetAll(), "Madon", "DiaChiNhanHang");
			ViewBag.MaSP = new SelectList(_chiTietDonHangRepository.GetAll(), "MaSP", "TenSP");
			return View();
		}

		// POST: ChiTietDonHangs/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "CTMaDon,MaDon,MaSP,SoLuong,DonGia,ThanhTien,PhuongThucThanhToan")] ChiTietDonHang chiTietDonHang)
		{
			if (ModelState.IsValid)
			{
				_chiTietDonHangRepository.Add(chiTietDonHang);
				return RedirectToAction("Index");
			}
			ViewBag.MaDon = new SelectList(_chiTietDonHangRepository.GetAll(), "Madon", "DiaChiNhanHang", chiTietDonHang.MaDon);
			ViewBag.MaSP = new SelectList(_chiTietDonHangRepository.GetAll(), "MaSP", "TenSP", chiTietDonHang.MaSP);
			return View(chiTietDonHang);
		}

		// GET: ChiTietDonHangs/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var chiTietDonHang = _chiTietDonHangRepository.GetById(id.Value);
			if (chiTietDonHang == null)
			{
				return HttpNotFound();
			}
			ViewBag.MaDon = new SelectList(_chiTietDonHangRepository.GetAll(), "Madon", "DiaChiNhanHang", chiTietDonHang.MaDon);
			ViewBag.MaSP = new SelectList(_chiTietDonHangRepository.GetAll(), "MaSP", "TenSP", chiTietDonHang.MaSP);
			return View(chiTietDonHang);
		}

		// POST: ChiTietDonHangs/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "CTMaDon,MaDon,MaSP,SoLuong,DonGia,ThanhTien,PhuongThucThanhToan")] ChiTietDonHang chiTietDonHang)
		{
			if (ModelState.IsValid)
			{
				_chiTietDonHangRepository.Update(chiTietDonHang);
				return RedirectToAction("Index");
			}
			ViewBag.MaDon = new SelectList(_chiTietDonHangRepository.GetAll(), "Madon", "DiaChiNhanHang", chiTietDonHang.MaDon);
			ViewBag.MaSP = new SelectList(_chiTietDonHangRepository.GetAll(), "MaSP", "TenSP", chiTietDonHang.MaSP);
			return View(chiTietDonHang);
		}

		// GET: ChiTietDonHangs/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var chiTietDonHang = _chiTietDonHangRepository.GetById(id.Value);
			if (chiTietDonHang == null)
			{
				return HttpNotFound();
			}
			return View(chiTietDonHang);
		}

		// POST: ChiTietDonHangs/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_chiTietDonHangRepository.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
