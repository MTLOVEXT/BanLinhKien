using CHBHTH.Areas.Admin.Repositories;
using CHBHTH.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CHBHTH.Areas.Admin.Controllers
{
	public class SanPhamsController : Controller
	{
		private readonly ISanPhamRepositoryAdmin _sanPhamRepository;

		// Khởi tạo controller với repository
		public SanPhamsController(ISanPhamRepositoryAdmin sanPhamRepository)
		{
			_sanPhamRepository = sanPhamRepository;
		}

		// GET: SanPhams
		public ActionResult Index()
		{
			var sanPhams = _sanPhamRepository.GetAllSanPhams();
			var u = Session["use"] as CHBHTH.Models.TaiKhoan;
			if (u.PhanQuyen.IDQuyen == 1 || u.PhanQuyen.IDQuyen == 3)
			{
				return View(sanPhams.OrderByDescending(s => s.MaSP).ToList());
			}
			return RedirectPermanent("~/Home/Index");
		}

		// GET: SanPhams/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SanPham sanPham = _sanPhamRepository.GetSanPhamById(id.Value);
			if (sanPham == null)
			{
				return HttpNotFound();
			}
			return View(sanPham);
		}

		// GET: SanPhams/Create
		public ActionResult Create()
		{
			// Fetch categories and suppliers for the dropdowns
			ViewBag.MaLoai = new SelectList(_sanPhamRepository.GetAllLoaiHangs(), "MaLoai", "TenLoai");
			ViewBag.MaNCC = new SelectList(_sanPhamRepository.GetAllNhaCungCaps(), "MaNCC", "TenNCC");
			return View();
		}

		// POST: SanPhams/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "MaSP,TenSP,GiaBan,Soluong,MoTa,MaLoai,MaNCC,AnhSP")] SanPham sanPham)
		{
			if (ModelState.IsValid)
			{
				_sanPhamRepository.AddSanPham(sanPham);
				_sanPhamRepository.Save();
				return RedirectToAction("Index");
			}

			// Repopulate dropdowns if model state is invalid
			ViewBag.MaLoai = new SelectList(_sanPhamRepository.GetAllLoaiHangs(), "MaLoai", "TenLoai", sanPham.MaLoai);
			ViewBag.MaNCC = new SelectList(_sanPhamRepository.GetAllNhaCungCaps(), "MaNCC", "TenNCC", sanPham.MaNCC);
			return View(sanPham);
		}

		// GET: SanPhams/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SanPham sanPham = _sanPhamRepository.GetSanPhamById(id.Value);
			if (sanPham == null)
			{
				return HttpNotFound();
			}

			// Fetch categories and suppliers for the dropdowns
			ViewBag.MaLoai = new SelectList(_sanPhamRepository.GetAllLoaiHangs(), "MaLoai", "TenLoai", sanPham.MaLoai);
			ViewBag.MaNCC = new SelectList(_sanPhamRepository.GetAllNhaCungCaps(), "MaNCC", "TenNCC", sanPham.MaNCC);

			return View(sanPham);
		}

		// POST: SanPhams/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(SanPham sanPham, HttpPostedFileBase AnhSP)
		{
			try
			{
				if (ModelState.IsValid)
				{
					// Kiểm tra xem ảnh có được chọn không
					if (AnhSP != null && AnhSP.ContentLength > 0)
					{
						// Lấy tên tệp
						string fileName = Path.GetFileName(AnhSP.FileName);
						// Lấy đường dẫn lưu ảnh
						string filePath = Path.Combine(Server.MapPath("~/Content/assets/img/"), fileName);

						// Kiểm tra nếu thư mục không tồn tại thì tạo mới
						if (!Directory.Exists(Server.MapPath("~/Content/assets/img/")))
						{
							Directory.CreateDirectory(Server.MapPath("~/Content/assets/img/"));
						}

						// Lưu tệp vào thư mục
						AnhSP.SaveAs(filePath);

						// Lưu đường dẫn ảnh vào đối tượng sanPham
						sanPham.AnhSP = "~/Content/assets/img/" + fileName;
					}

					// Cập nhật thông tin sản phẩm vào cơ sở dữ liệu
					_sanPhamRepository.UpdateSanPham(sanPham);
					_sanPhamRepository.Save();

					// Chuyển hướng về trang Index
					return RedirectToAction("Index");
				}

				// Nếu có lỗi, tạo lại danh sách các loại hàng và nhà cung cấp
				ViewBag.LoaiHangs = new SelectList(_sanPhamRepository.GetAllLoaiHangs(), "MaLoai", "TenLoai", sanPham.MaLoai);
				ViewBag.NhaCungCaps = new SelectList(_sanPhamRepository.GetAllNhaCungCaps(), "MaNCC", "TenNCC", sanPham.MaNCC);

				// Trả về view với thông tin lỗi
				return View(sanPham);
			}
			catch (Exception ex)
			{
				// Log lỗi chi tiết (có thể sử dụng các công cụ log như NLog, Serilog, hoặc ghi log vào cơ sở dữ liệu)
				// Bạn có thể thay thế Console.WriteLine bằng các công cụ log thực tế trong ứng dụng của mình
				Console.WriteLine("Error: " + ex.Message);
				// Hoặc ghi vào log file
				// Log.Error("Error in Edit: " + ex.Message);

				// Hiển thị thông báo lỗi cho người dùng
				ViewBag.ErrorMessage = "Đã xảy ra lỗi trong quá trình xử lý. Vui lòng thử lại sau.";

				// Tạo lại danh sách các loại hàng và nhà cung cấp để hiển thị trên trang sửa
				ViewBag.LoaiHangs = new SelectList(_sanPhamRepository.GetAllLoaiHangs(), "MaLoai", "TenLoai", sanPham.MaLoai);
				ViewBag.NhaCungCaps = new SelectList(_sanPhamRepository.GetAllNhaCungCaps(), "MaNCC", "TenNCC", sanPham.MaNCC);

				// Trả lại view với thông báo lỗi
				return View(sanPham);
			}
		}







		// GET: SanPhams/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SanPham sanPham = _sanPhamRepository.GetSanPhamById(id.Value);
			if (sanPham == null)
			{
				return HttpNotFound();
			}
			return View(sanPham);
		}

		// POST: SanPhams/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_sanPhamRepository.DeleteSanPham(id);
			_sanPhamRepository.Save();
			return RedirectToAction("Index");
		}
	}
}
