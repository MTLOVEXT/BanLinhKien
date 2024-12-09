using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CHBHTH.Areas.Admin.Repositories
{
	public class DonHangRepositoryAdmin : IDonHangRepositoryAdmin
	{
		private readonly QLbanhang _context;

		public DonHangRepositoryAdmin(QLbanhang context)
		{
			_context = context;
		}

		public IEnumerable<DonHang> GetAllDonHangs()
		{
			return _context.DonHangs.Include(d => d.TaiKhoan).OrderByDescending(d => d.MaDon).ToList();
		}

		public List<TaiKhoan> GetAllTaiKhoans()
		{
			return _context.TaiKhoans.ToList();
		}

		public DonHang GetDonHangById(int id)
		{
			return _context.DonHangs
						   .Include(dh => dh.TaiKhoan) // Tải thông tin TaiKhoan liên quan
						   .FirstOrDefault(dh => dh.MaDon == id);
		}

		public void AddDonHang(DonHang donHang)
		{
			_context.DonHangs.Add(donHang);
		}

		public void UpdateDonHang(DonHang donHang)
		{
			_context.Entry(donHang).State = EntityState.Modified;
		}

		public void DeleteDonHang(int id)
		{
			var donHang = _context.DonHangs.Find(id);
			if (donHang != null)
			{
				_context.DonHangs.Remove(donHang);
			}
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}