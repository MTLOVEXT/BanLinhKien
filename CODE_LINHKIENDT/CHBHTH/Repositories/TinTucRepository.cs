using System.Collections.Generic;
using System.Linq;
using CHBHTH.Models;

namespace CHBHTH.Repositories
{
	public class TinTucRepository : ITintucRepository
	{
		private readonly QLbanhang _context;

		public TinTucRepository(QLbanhang context)
		{
			_context = context;
		}

		public IEnumerable<TinTuc> GetAll()
		{
			return _context.TinTucs.ToList();
		}

		public IEnumerable<TinTuc> GetTop(int count)
		{
			return _context.TinTucs.Take(count).ToList();
		}

		public TinTuc GetById(int id)
		{
			return _context.TinTucs.SingleOrDefault(t => t.MaTT == id);
		}

		//public void Add(TinTuc tinTuc)
		//{
		//	_context.TinTucs.Add(tinTuc);
		//	_context.SaveChanges();
		//}

		//public void Update(TinTuc tinTuc)
		//{
		//	var existingTinTuc = _context.TinTucs.Find(tinTuc.MaTT);
		//	if (existingTinTuc != null)
		//	{
		//		_context.Entry(existingTinTuc).CurrentValues.SetValues(tinTuc);
		//		_context.SaveChanges();
		//	}
		//}

		//public void Delete(int id)
		//{
		//	var tinTuc = _context.TinTucs.Find(id);
		//	if (tinTuc != null)
		//	{
		//		_context.TinTucs.Remove(tinTuc);
		//		_context.SaveChanges();
		//	}
		//}
	}
}
