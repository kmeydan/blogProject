using Straßenkarte.Abstract.Repository;
using Straßenkarte.Enitites;
using Straßenkarte.Enitites.ContextSınıfı;

namespace Straßenkarte.Repository
{
	public class TodoRepository:BaseRepository<Todo>,ITodoRepository
	{
		public TodoRepository(AppDbContext dbContext) : base(dbContext)
		{

		}
	}
}
