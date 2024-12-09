using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHBHTH.Areas.Admin.Repositories
{
	public interface ISanPhamRepositoryAdmin
	{
		IEnumerable<LoaiHang> GetAllLoaiHangs(); // Fetch LoaiHangs
		IEnumerable<NhaCungCap> GetAllNhaCungCaps(); // Fetch NhaCungCaps
		IEnumerable<SanPham> GetAllSanPhams();
		SanPham GetSanPhamById(int id);
		void AddSanPham(SanPham sanPham);
		void UpdateSanPham(SanPham sanPham);
		void DeleteSanPham(int id);
		void Save();
	}
}
