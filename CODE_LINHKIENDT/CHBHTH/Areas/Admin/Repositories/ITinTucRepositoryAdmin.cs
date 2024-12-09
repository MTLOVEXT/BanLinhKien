namespace CHBHTH.Areas.Admin.Repositories
{
	using CHBHTH.Models;
	using System.Collections.Generic;

	public interface ITinTucRepositoryAdmin
	{
		IEnumerable<TinTuc> GetAll();
		TinTuc GetById(int id);
		void Add(TinTuc tinTuc);
		void Update(TinTuc tinTuc);
		void Delete(int id);
		void Save();
	}
}
