using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHBHTH.Areas.Admin.Repositories
{
	public interface IPhanQuyenRepository
	{
		IEnumerable<PhanQuyen> GetAll();
		PhanQuyen GetById(int id);
		void Add(PhanQuyen phanQuyen);
		void Update(PhanQuyen phanQuyen);
		void Delete(int id);
		void Save();
	}
}
