namespace CHBHTH.Areas.Admin.Repositories
{
	using CHBHTH.Models;
	using System.Collections.Generic;
	using System.Linq;

	public class ThongKeRepository : IThongKeRepository
	{
		private readonly QLbanhang _context;

		public ThongKeRepository(QLbanhang context)
		{
			_context = context;
		}

		// Get top 5 customers by total spend
		public IEnumerable<ThongKes> GetTopCustomers()
		{
			return (from s in _context.DonHangs
					join x in _context.TaiKhoans on s.MaNguoiDung equals x.MaNguoiDung
					group s by s.MaNguoiDung into g
					select new ThongKes
					{
						Tennguoidung = g.FirstOrDefault().TaiKhoan.HoTen,
						Tongtien = g.Sum(x => x.TongTien),
						Dienthoai = g.FirstOrDefault().TaiKhoan.Dienthoai,
						Soluong = g.Count()
					}).OrderByDescending(s => s.Tongtien).Take(5).ToList();
		}

		// Get top 5 best-selling products
		public IEnumerable<SanPham> GetBestSellingProducts()
		{
			var bestSellingProducts = (from d in _context.DonHangs
									   from c in _context.ChiTietDonHangs
									   where d.MaDon == c.MaDon
									   group c by c.MaSP into g
									   select new
									   {
										   TenSP = g.FirstOrDefault().SanPham.TenSP,
										   Soluong = g.Sum(x => x.SoLuong)
									   })
									   .OrderByDescending(p => p.Soluong)
									   .Take(5)
									   .ToList();

			// Now, map the anonymous type to SanPham objects
			var result = bestSellingProducts.Select(p => new SanPham
			{
				TenSP = p.TenSP,
				Soluong = p.Soluong
			}).ToList();

			return result;
		}

		public IEnumerable<SanPham> GetProductsSoldInYear(int year)
		{
			var productsSoldInYear = (from d in _context.DonHangs
									  from c in _context.ChiTietDonHangs
									  where d.MaDon == c.MaDon && d.NgayDat.HasValue && d.NgayDat.Value.Year == year
									  group c by c.MaSP into g
									  select new
									  {
										  TenSP = g.FirstOrDefault().SanPham.TenSP,
										  Soluong = g.Sum(x => x.SoLuong),
										  Nam = g.FirstOrDefault().DonHang.NgayDat.Value.Year
									  })
									   .OrderByDescending(p => p.Soluong)
									   .ToList();

			// Now, map the anonymous type to SanPham objects
			var result = productsSoldInYear.Select(p => new SanPham
			{
				TenSP = p.TenSP,
				Soluong = p.Soluong
			}).ToList();

			return result;
		}
	}
}
