using System.Collections.Generic;
using CHBHTH.Models;

namespace CHBHTH.Repositories
{
	public interface ISanPhamRepository
	{
		IEnumerable<SanPham> GetAll();
		IEnumerable<SanPham> GetByLoaiHang(int maLoai, int limit = 0);
        string GetTenLoaiHang(int maLoai);
        SanPham GetById(int maSP);
		void Add(SanPham sanPham);
		void Update(SanPham sanPham);
		void Delete(int maSP);

		void TruSoLuongSanPham(int maSP, int soLuongMua);

	}
}
