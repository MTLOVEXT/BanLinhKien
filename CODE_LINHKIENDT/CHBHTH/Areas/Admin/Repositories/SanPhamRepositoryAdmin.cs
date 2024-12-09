using CHBHTH.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CHBHTH.Areas.Admin.Repositories
{
	public class SanPhamRepositoryAdmin : ISanPhamRepositoryAdmin
	{
		private readonly QLbanhang _context;

		// Constructor that takes in the application database context
		public SanPhamRepositoryAdmin(QLbanhang context)
		{
			_context = context;
		}

		// Get all categories (LoaiHangs)
		public IEnumerable<LoaiHang> GetAllLoaiHangs()
		{
			return _context.LoaiHangs.ToList();
		}

		// Get all suppliers (NhaCungCaps)
		public IEnumerable<NhaCungCap> GetAllNhaCungCaps()
		{
			return _context.NhaCungCaps.ToList();
		}

		// Get all products (SanPhams)
		public IEnumerable<SanPham> GetAllSanPhams()
		{
			return _context.SanPhams.ToList();
		}

		// Get a product by its ID
		public SanPham GetSanPhamById(int id)
		{
			return _context.SanPhams.FirstOrDefault(s => s.MaSP == id);
		}

		// Add a new product
		public void AddSanPham(SanPham sanPham)
		{
			_context.SanPhams.Add(sanPham);
		}

		// Update an existing product
		public void UpdateSanPham(SanPham sanPham)
		{
			_context.Entry(sanPham).State = EntityState.Modified;
		}

		// Delete a product by its ID
		public void DeleteSanPham(int id)
		{
			// Tìm sản phẩm cần xóa
			SanPham sanPham = _context.SanPhams.FirstOrDefault(s => s.MaSP == id);

			if (sanPham != null)
			{
				// Tìm tất cả các bản ghi trong ChiTietDonHang tham chiếu đến sản phẩm này
				var chiTietDonHangs = _context.ChiTietDonHangs.Where(ct => ct.MaSP == sanPham.MaSP).ToList();

				// Nếu có bản ghi trong ChiTietDonHang, xóa chúng
				if (chiTietDonHangs.Any())
				{
					foreach (var item in chiTietDonHangs)
					{
						_context.ChiTietDonHangs.Remove(item); // Xóa từng bản ghi trong ChiTietDonHang
					}
				}

				// Sau khi xóa các bản ghi liên quan trong ChiTietDonHang, xóa sản phẩm
				_context.SanPhams.Remove(sanPham);

				// Lưu các thay đổi vào cơ sở dữ liệu
				Save();
			}
		}


		// Save changes to the database
		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
