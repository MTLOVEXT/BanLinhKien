﻿// IRepository.cs
using CHBHTH.Models;
using System.Collections.Generic;

public interface IUserRepository
{
	TaiKhoan GetUserByEmail(string email);
	IEnumerable<TaiKhoan> GetAllUsers();
	void AddUser(TaiKhoan taiKhoan);
	void Save();

	TaiKhoan GetUserById(int id);  // Lấy người dùng theo ID
	void Save(TaiKhoan taiKhoan);   // Lưu thông tin người dùng
	void Update(TaiKhoan taiKhoan); // Cập nhật thông tin người d
	void UpdatePassword(int userId, string newPassword);

}
