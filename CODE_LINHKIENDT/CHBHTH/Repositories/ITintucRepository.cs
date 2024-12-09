using System.Collections.Generic;
using CHBHTH.Models;

namespace CHBHTH.Repositories
{
	public interface ITintucRepository
	{
		IEnumerable<TinTuc> GetAll();
		IEnumerable<TinTuc> GetTop(int count);
		TinTuc GetById(int id);
	}
}
