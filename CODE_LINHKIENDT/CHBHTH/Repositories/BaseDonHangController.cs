using CHBHTH.Models;
using System.Collections.Generic;
using System.Web.Mvc;

public abstract class BaseDonHangController : Controller
{
	protected readonly IDonHangRepository _donHangRepository;

	// Constructor nhận repository để Dependency Injection
	public BaseDonHangController(IDonHangRepository donHangRepository)
	{
		_donHangRepository = donHangRepository;
	}

	// Logic chung cho việc hiển thị đơn hàng của người dùng
	protected IEnumerable<DonHang> GetDonHangsForUser(int userId)
	{
		return _donHangRepository.GetDonHangsByUser(userId);
	}

	// Logic chung cho việc lấy chi tiết đơn hàng
	protected IEnumerable<ChiTietDonHang> GetChiTietForDonHang(int donHangId)
	{
		return _donHangRepository.GetChiTietDonHangByDon(donHangId);
	}
}
