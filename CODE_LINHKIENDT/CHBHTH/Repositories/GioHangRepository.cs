using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CHBHTH.Models;
using Microsoft.Ajax.Utilities;

namespace CHBHTH.Repositories
{
	public class GioHangRepository : IGioHangRepository
	{
		private QLbanhang db = new QLbanhang();

		public List<GioHang> LayGioHang(object sessionGioHang)
		{
			if (sessionGioHang is System.Web.HttpSessionStateBase session)
			{
				if (!(session["GioHang"] is List<GioHang> gioHang))
				{
					gioHang = new List<GioHang>();
					session["GioHang"] = gioHang; // Tạo mới giỏ hàng nếu chưa có
				}
				return gioHang;
			}
			return new List<GioHang>(); // Trả về danh sách rỗng nếu session không hợp lệ
		}

		private SanPham GetProductById(int productId)
		{
			using (var db = new QLbanhang())
			{
				return db.SanPhams.SingleOrDefault(sp => sp.MaSP == productId);
			}
		}

		public void ThemGioHang(int productId, object sessionGioHang)
		{
			var gioHang = LayGioHang(sessionGioHang);
			var sp = gioHang.FirstOrDefault(x => x.iMasp == productId);

			if (sp == null)
			{
				var sanPham = GetProductById(productId);
				if (sanPham != null)
				{
					gioHang.Add(new GioHang(sanPham.MaSP)
					{
						iMasp = sanPham.MaSP,
						sTensp = sanPham.TenSP,
						sAnhBia = sanPham.AnhSP,
						dDonGia = (double)sanPham.GiaBan.Value,
						iSoLuong = 1
					});
				}
			}
			else
			{
				sp.iSoLuong++;
			}

			SaveGioHangToSession(sessionGioHang, gioHang);
		}

		public bool CapNhatGioHang(int productId, int soLuong, object sessionGioHang)
		{
			var gioHang = LayGioHang(sessionGioHang);
			var sp = gioHang.SingleOrDefault(x => x.iMasp == productId);

			if (sp != null)
			{
				if (soLuong > 0)
				{
					sp.iSoLuong = soLuong;
				}
				else
				{
					gioHang.Remove(sp);
				}
			}

			SaveGioHangToSession(sessionGioHang, gioHang);
			return gioHang.Any();
		}

		public bool XoaGioHang(int productId, object sessionGioHang)
		{
			var gioHang = LayGioHang(sessionGioHang);
			var sp = gioHang.SingleOrDefault(x => x.iMasp == productId);

			if (sp != null)
			{
				gioHang.Remove(sp);
			}

			SaveGioHangToSession(sessionGioHang, gioHang);
			return !gioHang.Any();
		}

		public int TongSoLuong(object sessionGioHang)
		{
			var gioHang = LayGioHang(sessionGioHang);
			return gioHang.Sum(x => x.iSoLuong);
		}

		public double TongTien(object sessionGioHang)
		{
			// Lấy giỏ hàng từ session
			var gioHang = LayGioHang(sessionGioHang);

			// Kiểm tra giỏ hàng có rỗng không
			if (gioHang == null || !gioHang.Any())
			{
				return 0;
			}

			// Tính tổng tiền bằng cách cộng dồn thành tiền của từng sản phẩm
			double tongTien = gioHang.Sum(x => x.ThanhTien);

			return tongTien;
		}


		private void SaveGioHangToSession(object sessionGioHang, List<GioHang> gioHang)
		{
			if (sessionGioHang is System.Web.HttpSessionStateBase session)
			{
				session["GioHang"] = gioHang;
			}
		}

		public void ClearCart(HttpSessionStateBase session)
		{
			session["GioHang"] = null;  // Xóa giỏ hàng trong session
		}

		public decimal TongTien(HttpSessionStateBase session)
		{
			// Lấy giỏ hàng từ session
			var gioHang = session["GioHang"] as List<GioHang>;

			if (gioHang == null || !gioHang.Any())
			{
				return 0;
			}

			// Tính tổng tiền bằng cách cộng thành tiền của từng sản phẩm
			return (decimal)gioHang.Sum(item => item.ThanhTien);
		}

	}
}
