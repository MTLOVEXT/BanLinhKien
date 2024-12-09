using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHBHTH.Models
{
    public class GioHang
    {
        //private int iMaSP;

        //public int IMaSP
        //{
        //    get { return iMaSP; }
        //    set { iMaSP = value; }
        //}
        private QLbanhang db = new QLbanhang();
        public int iMasp { get; set; }
        public string sTensp { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
		// Hàm tạo cho giỏ hàng
		public GioHang(int Masp)
		{
			iMasp = Masp;

			// Kiểm tra sự tồn tại của sản phẩm trong cơ sở dữ liệu
			SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == iMasp);

			if (sp != null)
			{
				sTensp = sp.TenSP;
				sAnhBia = sp.AnhSP;
				dDonGia = double.Parse(sp.GiaBan.ToString());
				iSoLuong = 1;
			}
			else
			{
				// Xử lý trường hợp sản phẩm không tồn tại
				throw new Exception("Sản phẩm không tồn tại.");
			}
		}

	}
}