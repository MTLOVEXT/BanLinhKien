using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHBHTH.Areas.Admin.Repositories
{
	public interface ILoaiHangRepository
	{
		IEnumerable<LoaiHang> GetAll();
		LoaiHang GetById(int id);
		void Add(LoaiHang loaiHang);
		void Update(LoaiHang loaiHang);
		void Delete(int id);
		void Save();
	}
}
