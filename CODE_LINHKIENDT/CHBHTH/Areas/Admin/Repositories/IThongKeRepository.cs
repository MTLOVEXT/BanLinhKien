namespace CHBHTH.Areas.Admin.Repositories
{
	using CHBHTH.Models;
	using System.Collections.Generic;

	public interface IThongKeRepository
	{
		IEnumerable<ThongKes> GetTopCustomers();
		IEnumerable<SanPham> GetBestSellingProducts();
		IEnumerable<SanPham> GetProductsSoldInYear(int year);

	}
}
