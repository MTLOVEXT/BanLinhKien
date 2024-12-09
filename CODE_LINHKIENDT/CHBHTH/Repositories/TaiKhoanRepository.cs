using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHBHTH.Repositories
{
	public class TaiKhoanRepository : ITaiKhoanRepository
	{
		private readonly QLbanhang _db;

		public TaiKhoanRepository()
		{
			_db = new QLbanhang();
		}

		public TaiKhoan GetNguoiDungBySession(object sessionUser)
		{
			return sessionUser as TaiKhoan;
		}

		public IEnumerable<TaiKhoan> GetAllTaiKhoans()
		{
			return _db.TaiKhoans.ToList();
		}
	}
}