using CHBHTH.Models;
using System.Collections.Generic;
using System.Web.Mvc;

public interface IDonHangRepository
{
	IEnumerable<DonHang> GetDonHangsByUser(int userId);
	DonHang GetDonHangById(int id);
	IEnumerable<ChiTietDonHang> GetChiTietDonHangByDon(int donHangId);
	void AddDonHang(DonHang donHang);
	void UpdateDonHang(DonHang donHang);
	void DeleteDonHang(int id);
	void Save();
	//Thanh Toán 
	void SaveOrder(DonHang donHang);
	void SaveOrderDetail(ChiTietDonHang chiTietDonHang);

	void UpdateOrder(DonHang donHang);


}
