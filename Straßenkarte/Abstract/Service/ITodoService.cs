using Straßenkarte.Enitites;
using System.Collections.Generic;

namespace Straßenkarte.Abstract.Service
{
	public interface ITodoService
	{
		List<Todo> GetAll();
		Todo GetById(int id);
		void Create(Todo todo);
		void Delete(Todo todo);
		void Update(Todo todo);
	}
}
