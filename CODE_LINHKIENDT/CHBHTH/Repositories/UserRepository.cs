// UserRepository.cs
using CHBHTH.Models;
using System.Collections.Generic;
using System.Linq;

public class UserRepository : IUserRepository
{
	private readonly QLbanhang _dbContext;

	public UserRepository(QLbanhang dbContext)
	{
		_dbContext = dbContext;
	}

	public TaiKhoan GetUserByEmail(string email)
	{
		return _dbContext.TaiKhoans.SingleOrDefault(x => x.Email.Equals(email));
	}

	public IEnumerable<TaiKhoan> GetAllUsers()
	{
		return _dbContext.TaiKhoans.ToList();
	}

	public void AddUser(TaiKhoan taiKhoan)
	{
		_dbContext.TaiKhoans.Add(taiKhoan);
		Save();
	}

	public void Save()
	{
		_dbContext.SaveChanges();
	}

	public TaiKhoan GetUserById(int id)
	{
		return _dbContext.TaiKhoans.SingleOrDefault(x => x.MaNguoiDung == id);
	}

	public void Save(TaiKhoan taiKhoan)
	{
		_dbContext.TaiKhoans.Add(taiKhoan);
		_dbContext.SaveChanges();
	}

	public void Update(TaiKhoan taiKhoan)
	{
		var existingUser = _dbContext.TaiKhoans.Find(taiKhoan.MaNguoiDung);
		if (existingUser != null)
		{
			existingUser.HoTen = taiKhoan.HoTen;
			existingUser.Email = taiKhoan.Email;
			existingUser.Dienthoai = taiKhoan.Dienthoai;
			existingUser.Matkhau = taiKhoan.Matkhau;
			existingUser.Diachi = taiKhoan.Diachi;
			existingUser.IDQuyen = taiKhoan.IDQuyen;

			_dbContext.SaveChanges();
		}
	}

	public void UpdatePassword(int userId, string newPassword)
	{
		var user = _dbContext.TaiKhoans.Find(userId);
		if (user != null)
		{
			user.Matkhau = newPassword; // Bạn có thể mã hóa mật khẩu ở đây
			_dbContext.SaveChanges();
		}
	}
}
