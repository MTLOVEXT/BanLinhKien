using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CHBHTH.Areas.Admin.Repositories
{
	public class PhanQuyenRepository : IPhanQuyenRepository
	{
		private readonly QLbanhang _dbContext;

		public PhanQuyenRepository(QLbanhang dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<PhanQuyen> GetAll()
		{
			return _dbContext.PhanQuyens.ToList();
		}

		public PhanQuyen GetById(int id)
		{
			return _dbContext.PhanQuyens.Find(id);
		}

		public void Add(PhanQuyen phanQuyen)
		{
			_dbContext.PhanQuyens.Add(phanQuyen);
		}

		public void Update(PhanQuyen phanQuyen)
		{
			_dbContext.Entry(phanQuyen).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			PhanQuyen phanQuyen = _dbContext.PhanQuyens.Find(id);
			if (phanQuyen != null)
			{
				_dbContext.PhanQuyens.Remove(phanQuyen);
			}
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}
	}
}