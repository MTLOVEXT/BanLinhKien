using CHBHTH.Models;
using System;
using System.Collections.Generic;

public interface IDanhMucRepository
{
	IEnumerable<LoaiHang> GetLoaiHangs();
	LoaiHang GetLoaiHangById(int id);
	IEnumerable<LoaiHang> GetLoaiHangsByCondition(Func<LoaiHang, bool> condition);
}
