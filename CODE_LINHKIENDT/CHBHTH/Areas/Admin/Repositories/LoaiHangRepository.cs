namespace CHBHTH.Areas.Admin.Repositories
{
	using CHBHTH.Models;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;

	public class LoaiHangRepository : ILoaiHangRepository
	{
		private readonly QLbanhang _context;

		public LoaiHangRepository(QLbanhang context)
		{
			_context = context;
		}

		public IEnumerable<LoaiHang> GetAll()
		{
			return _context.LoaiHangs.ToList();
		}

		public LoaiHang GetById(int id)
		{
			return _context.LoaiHangs.Find(id);
		}

		public void Add(LoaiHang loaiHang)
		{
			_context.LoaiHangs.Add(loaiHang);
		}

		public void Update(LoaiHang loaiHang)
		{
			_context.Entry(loaiHang).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			var loaiHang = _context.LoaiHangs.Find(id);

			if (loaiHang != null)
			{
				// Xóa các sản phẩm có MaLoai tham chiếu đến LoaiHang này
				var products = _context.SanPhams.Where(p => p.MaLoai == id).ToList();

				if (products.Any())
				{
					foreach (var product in products)
					{
						// Xóa các bản ghi trong ChiTietDonHang tham chiếu đến sản phẩm
						var chiTietDonHangs = _context.ChiTietDonHangs.Where(ct => ct.MaSP == product.MaSP).ToList();
						if (chiTietDonHangs.Any())
						{
							foreach (var item in chiTietDonHangs)
							{
								_context.ChiTietDonHangs.Remove(item); // Xóa từng bản ghi trong ChiTietDonHang
							}
						}

						_context.SanPhams.Remove(product); // Xóa sản phẩm
					}
				}

				// Sau khi xóa các sản phẩm và các bản ghi liên quan, xóa loại hàng
				_context.LoaiHangs.Remove(loaiHang);

				// Lưu các thay đổi vào cơ sở dữ liệu
				Save();
			}
		}



		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
