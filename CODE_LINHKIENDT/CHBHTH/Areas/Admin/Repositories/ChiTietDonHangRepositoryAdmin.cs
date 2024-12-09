using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CHBHTH.Areas.Admin.Repositories
{
	public class ChiTietDonHangRepositoryAdmin : IChiTietDonHangRepositoryAdmin
	{
		private readonly QLbanhang _db;

		public ChiTietDonHangRepositoryAdmin(QLbanhang db)
		{
			_db = db;
		}

		public IEnumerable<ChiTietDonHang> GetAll()
		{
			return _db.ChiTietDonHangs.Include(c => c.DonHang).Include(c => c.SanPham).ToList();
		}

		public ChiTietDonHang GetById(int id)
		{
			return _db.ChiTietDonHangs.Find(id);
		}

		public void Add(ChiTietDonHang chiTietDonHang)
		{
			_db.ChiTietDonHangs.Add(chiTietDonHang);
			_db.SaveChanges();
		}

		public void Update(ChiTietDonHang chiTietDonHang)
		{
			_db.Entry(chiTietDonHang).State = EntityState.Modified;
			_db.SaveChanges();
		}

		public void Delete(int id)
		{
			var chiTietDonHang = _db.ChiTietDonHangs.Find(id);
			if (chiTietDonHang != null)
			{
				_db.ChiTietDonHangs.Remove(chiTietDonHang);
				_db.SaveChanges();
			}
		}
		public IEnumerable<ChiTietDonHang> GetByOrderId(int orderId)
		{
			return _db.ChiTietDonHangs
						   .Include(ct => ct.SanPham) // Bao gồm thông tin sản phẩm
						   .Where(ct => ct.MaDon == orderId)
						   .ToList();
		}
		// Phương thức xóa chi tiết đơn hàng theo MaDon
		public void DeleteChiTietDonHangsByOrderId(int orderId)
		{
			// Tìm các chi tiết đơn hàng theo MaDon
			var chiTietDonHangs = _db.ChiTietDonHangs.Where(ct => ct.MaDon == orderId).ToList();

			if (chiTietDonHangs.Any())
			{
				// Xóa tất cả chi tiết đơn hàng
				_db.ChiTietDonHangs.RemoveRange(chiTietDonHangs);
				_db.SaveChanges();
			}
		}
	}
}