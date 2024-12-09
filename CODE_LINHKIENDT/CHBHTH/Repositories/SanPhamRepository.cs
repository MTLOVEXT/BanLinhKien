using System.Collections.Generic;
using System.Linq;
using CHBHTH.Models;
using System.Data.Entity;
using System;

namespace CHBHTH.Repositories
{
	public class SanPhamRepository : ISanPhamRepository
	{
		private readonly QLbanhang _context;

		public SanPhamRepository(QLbanhang context)
		{
			_context = context;
		}

		public IEnumerable<SanPham> GetAll()
		{
			return _context.SanPhams.Include(s => s.LoaiHang).Include(s => s.NhaCungCap).ToList();
		}

		public IEnumerable<SanPham> GetByLoaiHang(int maLoai, int limit = 0)
		{
			var query = _context.SanPhams.Where(s => s.MaLoai == maLoai);
			return limit > 0 ? query.Take(limit).ToList() : query.ToList();
		}
        public string GetTenLoaiHang(int maLoai)
        {
            var loaiHang = _context.LoaiHangs.FirstOrDefault(l => l.MaLoai == maLoai);
            return loaiHang?.TenLoai ?? "Không xác định"; // Trả về tên loại hoặc thông báo nếu không tìm thấy
        }

        public SanPham GetById(int maSP)
		{
			return _context.SanPhams.SingleOrDefault(s => s.MaSP == maSP);
		}

		public void Add(SanPham sanPham)
		{
			_context.SanPhams.Add(sanPham);
			_context.SaveChanges();
		}

		public void Update(SanPham sanPham)
		{
			var existingSanPham = _context.SanPhams.Find(sanPham.MaSP);
			if (existingSanPham != null)
			{
				_context.Entry(existingSanPham).CurrentValues.SetValues(sanPham);
				_context.SaveChanges();
			}
		}

		public void Delete(int maSP)
		{
			var sanPham = _context.SanPhams.Find(maSP);
			if (sanPham != null)
			{
				_context.SanPhams.Remove(sanPham);
				_context.SaveChanges();
			}
		}

		// Phương thức trừ số lượng sản phẩm khi đặt hàng
		public void TruSoLuongSanPham(int maSP, int soLuongMua)
		{
			var sanPham = _context.SanPhams.SingleOrDefault(sp => sp.MaSP == maSP);

			if (sanPham != null)
			{
				// Kiểm tra nếu số lượng tồn kho đủ
				if (sanPham.Soluong >= soLuongMua)
				{
					sanPham.Soluong -= soLuongMua;
					_context.SaveChanges();  // Lưu lại thay đổi trong cơ sở dữ liệu
				}
				else
				{
					throw new Exception("Số lượng sản phẩm trong kho không đủ.");
				}
			}
			else
			{
				throw new Exception("Sản phẩm không tồn tại.");
			}
		}


	}
}
