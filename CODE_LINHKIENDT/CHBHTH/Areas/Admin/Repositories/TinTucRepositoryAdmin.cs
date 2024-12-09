namespace CHBHTH.Areas.Admin.Repositories
{
	using CHBHTH.Models;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;

	public class TinTucRepositoryAdmin : ITinTucRepositoryAdmin
	{
		private readonly QLbanhang _context;

		public TinTucRepositoryAdmin(QLbanhang context)
		{
			_context = context;
		}

		public IEnumerable<TinTuc> GetAll()
		{
			return _context.TinTucs.ToList();
		}

		public TinTuc GetById(int id)
		{
			return _context.TinTucs.Find(id);
		}

		public void Add(TinTuc tinTuc)
		{
			_context.TinTucs.Add(tinTuc);
		}

		public void Update(TinTuc tinTuc)
		{
			_context.Entry(tinTuc).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			var tinTuc = _context.TinTucs.Find(id);
			if (tinTuc != null)
			{
				_context.TinTucs.Remove(tinTuc);
			}
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
