using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class DanhMucRepository : IDanhMucRepository
{
	private QLbanhang db;

	public DanhMucRepository(QLbanhang context)
	{
		db = context;
	}

	public IEnumerable<LoaiHang> GetLoaiHangs()
	{
		return db.LoaiHangs.ToList();
	}

	public LoaiHang GetLoaiHangById(int id)
	{
		return db.LoaiHangs.Find(id);
	}

	public IEnumerable<LoaiHang> GetLoaiHangsByCondition(Func<LoaiHang, bool> condition)
	{
		return db.LoaiHangs.Where(condition).ToList();
	}
}
