using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CHBHTH.Models;
using CHBHTH.Repositories;

namespace CHBHTH.Areas.Admin.Repositories
{
	public class TaiKhoanRepositoryAdmnin : ITaiKhoanRepositoryAdmin
	{
		private QLbanhang db;

		public TaiKhoanRepositoryAdmnin(QLbanhang context)
		{
			db = context;
		}

		public IEnumerable<TaiKhoan> GetAllTaiKhoans()
		{
			return db.TaiKhoans.Include(t => t.PhanQuyen).ToList();
		}

		public TaiKhoan GetTaiKhoanById(int id)
		{
			return db.TaiKhoans.Find(id);
		}

		public void AddTaiKhoan(TaiKhoan taiKhoan)
		{
			db.TaiKhoans.Add(taiKhoan);
		}

		public void UpdateTaiKhoan(TaiKhoan taiKhoan)
		{
			db.Entry(taiKhoan).State = EntityState.Modified;
		}

		public void DeleteTaiKhoan(int id)
		{
			TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
			if (taiKhoan != null)
			{
				db.TaiKhoans.Remove(taiKhoan);
			}
		}

		public void Save()
		{
			db.SaveChanges();
		}

		public bool IsUserAdministrator(TaiKhoan user)
		{
			// Kiểm tra nếu user null hoặc IDQuyen khác 1 thì trả về false
			if (user == null || user.IDQuyen != 1)
			{
				return false;
			}

			// Nếu IDQuyen là 1, trả về true
			return true;
		}


	}
}
