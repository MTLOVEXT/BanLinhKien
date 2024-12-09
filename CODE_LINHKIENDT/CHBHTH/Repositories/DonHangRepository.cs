using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;

public class DonHangRepository : IDonHangRepository
{
	private QLbanhang db;

	public DonHangRepository()
	{
		db = new QLbanhang();
	}

	public IEnumerable<DonHang> GetDonHangsByUser(int userId)
	{
		return db.DonHangs.Include(d => d.TaiKhoan).Where(d => d.MaNguoiDung == userId).ToList();
	}

	public DonHang GetDonHangById(int id)
	{
		return db.DonHangs.Find(id);
	}

	public IEnumerable<ChiTietDonHang> GetChiTietDonHangByDon(int donHangId)
	{
		return db.ChiTietDonHangs.Include(d => d.SanPham).Where(d => d.MaDon == donHangId).ToList();
	}

	public void AddDonHang(DonHang donHang)
	{
		db.DonHangs.Add(donHang);
	}

	public void UpdateDonHang(DonHang donHang)
	{
		db.Entry(donHang).State = EntityState.Modified;
	}

	public void DeleteDonHang(int id)
	{
		DonHang donHang = db.DonHangs.Find(id);
		if (donHang != null)
		{
			db.DonHangs.Remove(donHang);
		}
	}

	public void Save()
	{
		db.SaveChanges();
	}

	public void SaveOrder(DonHang donHang)
	{
		using (var db = new QLbanhang())
		{
			// Thêm đơn hàng vào cơ sở dữ liệu
			db.DonHangs.Add(donHang);

			// Lưu thay đổi
			db.SaveChanges();
		}
	}

	public void SaveOrderDetail(ChiTietDonHang chiTietDonHang)
	{
		using (var db = new QLbanhang())
		{
			// Thêm chi tiết đơn hàng vào cơ sở dữ liệu
			db.ChiTietDonHangs.Add(chiTietDonHang);

			// Lưu thay đổi
			db.SaveChanges();
		}
	}


	public void UpdateOrder(DonHang donHang)
	{
		if (donHang == null)
		{
			throw new ArgumentNullException(nameof(donHang), "Đơn hàng không được null.");
		}

		var existingOrder = db.DonHangs.SingleOrDefault(dh => dh.MaDon == donHang.MaDon);

		if (existingOrder == null)
		{
			throw new InvalidOperationException($"Không tìm thấy đơn hàng với mã {donHang.MaDon}.");
		}

		// Cập nhật thông tin đơn hàng
		existingOrder.NgayDat = donHang.NgayDat ?? existingOrder.NgayDat;
		existingOrder.TinhTrang = donHang.TinhTrang ?? existingOrder.TinhTrang;
		existingOrder.ThanhToan = donHang.ThanhToan ?? existingOrder.ThanhToan;
		existingOrder.DiaChiNhanHang = !string.IsNullOrEmpty(donHang.DiaChiNhanHang) ? donHang.DiaChiNhanHang : existingOrder.DiaChiNhanHang;
		existingOrder.MaNguoiDung = donHang.MaNguoiDung ?? existingOrder.MaNguoiDung;
		existingOrder.TongTien = donHang.TongTien ?? existingOrder.TongTien;

		// Lưu thay đổi vào database
		db.SaveChanges();
	}

}
