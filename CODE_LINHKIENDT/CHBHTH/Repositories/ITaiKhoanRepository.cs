using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHBHTH.Repositories
{
	public interface ITaiKhoanRepository
	{
		TaiKhoan GetNguoiDungBySession(object sessionUser);
		IEnumerable<TaiKhoan> GetAllTaiKhoans();
	}
}
