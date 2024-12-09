using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

public abstract class BaseDanhMucController : Controller
{
	protected readonly IDanhMucRepository _danhMucRepository;

	// Constructor nhận repository để Dependency Injection
	public BaseDanhMucController(IDanhMucRepository danhMucRepository)
	{
		_danhMucRepository = danhMucRepository;
	}

	// Logic chung cho việc lấy tất cả các LoaiHang
	protected IEnumerable<LoaiHang> GetLoaiHangs()
	{
		return _danhMucRepository.GetLoaiHangs();
	}

	// Logic chung cho việc lấy LoaiHang theo điều kiện
	protected IEnumerable<LoaiHang> GetLoaiHangsByCondition(Func<LoaiHang, bool> condition)
	{
		return _danhMucRepository.GetLoaiHangsByCondition(condition);
	}
}
