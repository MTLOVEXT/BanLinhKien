using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHBHTH.Areas.Admin.Repositories
{
	public interface IDonHangRepositoryAdmin
	{
		IEnumerable<DonHang> GetAllDonHangs();
		List<TaiKhoan> GetAllTaiKhoans();

		DonHang GetDonHangById(int id);
		void AddDonHang(DonHang donHang);
		void UpdateDonHang(DonHang donHang);
		void DeleteDonHang(int id);
		void Save();
	}
}
