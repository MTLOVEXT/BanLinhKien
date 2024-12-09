using System.Collections.Generic;
using CHBHTH.Models;

namespace CHBHTH.Areas.Admin.Repositories
{
	public interface ITaiKhoanRepositoryAdmin
	{
		IEnumerable<TaiKhoan> GetAllTaiKhoans();
		TaiKhoan GetTaiKhoanById(int id);
		void AddTaiKhoan(TaiKhoan taiKhoan);
		void UpdateTaiKhoan(TaiKhoan taiKhoan);
		void DeleteTaiKhoan(int id);
		void Save();
		bool IsUserAdministrator(TaiKhoan user);

	}
}
