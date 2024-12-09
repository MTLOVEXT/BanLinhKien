using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHBHTH.Areas.Admin.Repositories
{
	public interface INhaCungCapRepository
	{
		IEnumerable<NhaCungCap> GetAll();
		NhaCungCap GetById(int id);
		void Add(NhaCungCap nhaCungCap);
		void Update(NhaCungCap nhaCungCap);
		void Delete(int id);
		void Save();
	}
}
