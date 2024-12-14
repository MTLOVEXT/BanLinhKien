using System.Collections.Generic;
using System.Web;
using CHBHTH.Models;

namespace CHBHTH.Repositories
{
	public interface IGioHangRepository
	{
		List<GioHang> LayGioHang(object sessionGioHang);
		void ThemGioHang(int productId, object sessionGioHang);
		bool CapNhatGioHang(int productId, int soLuong, object sessionGioHang);
		bool XoaGioHang(int productId, object sessionGioHang);
		int TongSoLuong(object sessionGioHang);
		double TongTien(object sessionGioHang);
		void ClearCart(HttpSessionStateBase session);

		//Thanh Toán
		decimal TongTien(HttpSessionStateBase session);
		string KiemTraSoLuongSanPham(int productId, int soLuongCanMua, object sessionGioHang);

	}
}
