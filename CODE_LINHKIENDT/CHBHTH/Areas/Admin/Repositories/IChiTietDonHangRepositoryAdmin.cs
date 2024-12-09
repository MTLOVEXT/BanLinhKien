using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHBHTH.Areas.Admin.Repositories
{
	public interface IChiTietDonHangRepositoryAdmin
	{
		IEnumerable<ChiTietDonHang> GetAll();
		ChiTietDonHang GetById(int id);
		void Add(ChiTietDonHang chiTietDonHang);
		void Update(ChiTietDonHang chiTietDonHang);
		void Delete(int id);
		IEnumerable<ChiTietDonHang> GetByOrderId(int orderId);
		void DeleteChiTietDonHangsByOrderId(int orderId);

	}
}
