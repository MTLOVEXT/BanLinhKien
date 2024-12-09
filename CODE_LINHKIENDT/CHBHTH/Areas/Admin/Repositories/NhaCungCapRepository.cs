using CHBHTH.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CHBHTH.Areas.Admin.Repositories
{
	public class NhaCungCapRepository : INhaCungCapRepository
	{
		private readonly QLbanhang _context;

		public NhaCungCapRepository(QLbanhang context)
		{
			_context = context;
		}

		// Get all NhaCungCap
		public IEnumerable<NhaCungCap> GetAll()
		{
			return _context.NhaCungCaps.ToList();
		}

		// Get NhaCungCap by ID
		public NhaCungCap GetById(int id)
		{
			return _context.NhaCungCaps.Find(id);
		}

		// Add a new NhaCungCap
		public void Add(NhaCungCap nhaCungCap)
		{
			_context.NhaCungCaps.Add(nhaCungCap);
		}

		// Update an existing NhaCungCap
		public void Update(NhaCungCap nhaCungCap)
		{
			_context.Entry(nhaCungCap).State = EntityState.Modified;
		}

		// Delete a NhaCungCap by ID
		public void Delete(int id)
		{
			NhaCungCap nhaCungCap = _context.NhaCungCaps.Find(id);
			if (nhaCungCap != null)
			{
				_context.NhaCungCaps.Remove(nhaCungCap);
			}
		}

		// Save changes to the database
		public void Save()
		{
			_context.SaveChanges();
		}
	}
}