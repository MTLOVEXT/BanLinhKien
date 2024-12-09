using CHBHTH.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CHBHTH.Controllers
{
    public class UserController : Controller
    {
        QLbanhang db = new QLbanhang();
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		// ĐĂNG KÝ
		public ActionResult Dangky()
        {
            return View();
        }

		// ĐĂNG KÝ PHƯƠNG THỨC POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Dangky(TaiKhoan taiKhoan)
		{
			try
			{
				Session["userReg"] = taiKhoan;

				if (ModelState.IsValid)
				{
					var check = _userRepository.GetUserByEmail(taiKhoan.Email);
					if (check == null)
					{
						ViewBag.RegOk = "Đăng kí thành công. Đăng nhập ngay";
						ViewBag.isReg = true;
						_userRepository.AddUser(taiKhoan);
						return View("Dangky");
					}
					else
					{
						ViewBag.RegOk = "Email đã tồn tại! Vui lòng chọn 1 email khác";
						return View("Dangky");
					}
				}

				return View("Dangky");
			}
			catch
			{
				return View();
			}
		}

        [AllowAnonymous]
        public ActionResult Dangnhap()
        {
            return View();

        }


        [HttpPost]
		public ActionResult Dangnhap(FormCollection userlog)
		{
			string userMail = userlog["userMail"].ToString();
			string password = userlog["password"].ToString();

			// Lấy thông tin tài khoản từ email
			var user = _userRepository.GetUserByEmail(userMail);

			if (user != null)
			{
				// Kiểm tra mật khẩu (so sánh trực tiếp)
				if (user.Matkhau == password) // So sánh mật khẩu trực tiếp
				{
					// Đăng nhập thành công, lưu thông tin vào session
					Session["use"] = user;

					// Kiểm tra quyền hạn người dùng
					if (user.IDQuyen == 1 || user.IDQuyen == 3) // Quản trị viên
					{
						return RedirectToAction("Index", "Admin/Home");
					}
					else // Người dùng thông thường
					{
						return RedirectToAction("Index", "Home");
					}
				}
				else
				{
					// Mật khẩu sai
					ViewBag.Fail = "Tài khoản hoặc mật khẩu không chính xác.";
					return View("Dangnhap");
				}
			}
			else
			{
				// Tài khoản không tồn tại
				ViewBag.Fail = "Tài khoản không tồn tại.";
				return View("Dangnhap");
			}
		}

		public ActionResult DangXuat()
        {
            Session["use"] = null;
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Profile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			TaiKhoan taiKhoan = _userRepository.GetAllUsers().FirstOrDefault(x => x.MaNguoiDung == id);
			if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

		// GET: Edit thông tin cá nhân
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			// Lấy thông tin người dùng từ repository
			TaiKhoan taiKhoan = _userRepository.GetUserById(id.Value);
			if (taiKhoan == null)
			{
				return HttpNotFound();
			}

			ViewBag.IDQuyen = new SelectList(_userRepository.GetAllUsers(), "IDQuyen", "TenQuyen", taiKhoan.IDQuyen);
			return View(taiKhoan);
		}

		// POST: Edit thông tin cá nhân
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "MaNguoiDung,HoTen,Email,Dienthoai,Matkhau,IDQuyen,Diachi")] TaiKhoan taiKhoan)
		{
			if (ModelState.IsValid)
			{
				// Lưu thông tin người dùng đã chỉnh sửa
				_userRepository.Update(taiKhoan);

				// Sau khi lưu, chuyển đến trang Profile hoặc trang khác
				return RedirectToAction("Profile", new { id = taiKhoan.MaNguoiDung });
			}

			// Nếu có lỗi, giữ lại thông tin cũ và hiển thị lỗi
			ViewBag.IDQuyen = new SelectList(_userRepository.GetAllUsers(), "IDQuyen", "TenQuyen", taiKhoan.IDQuyen);
			return View(taiKhoan);
		}

		public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        public static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }

		// GET: Forgot Password
		public ActionResult ForgotPassword()
		{
			return View(); // Trả về trang quên mật khẩu
		}


		// POST: Forgot Password
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ForgotPassword(string Email, string Matkhau, string ConfirmMatkhau)
		{
			// Kiểm tra email không rỗng
			if (string.IsNullOrEmpty(Email))
			{
				ViewBag.ErrorMessage = "Vui lòng nhập email.";
				return View();
			}

			// Tìm người dùng theo email
			var user = _userRepository.GetUserByEmail(Email);
			if (user == null)
			{
				ViewBag.ErrorMessage = "Email không tồn tại trong hệ thống.";
				return View();
			}

			// Kiểm tra mật khẩu khớp
			if (Matkhau != ConfirmMatkhau)
			{
				ViewBag.ErrorMessage = "Mật khẩu mới và xác nhận mật khẩu không khớp.";
				return View();
			}

			// Cập nhật mật khẩu
			try
			{
				_userRepository.UpdatePassword(user.MaNguoiDung, Matkhau);
				ViewBag.SuccessMessage = "Mật khẩu đã được đặt lại thành công.";
				return View();
			}
			catch (Exception ex)
			{
				ViewBag.ErrorMessage = "Đã xảy ra lỗi trong quá trình đặt lại mật khẩu.";
				return View();
			}
		}

	}
}