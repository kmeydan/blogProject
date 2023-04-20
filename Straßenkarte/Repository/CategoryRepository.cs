using Straßenkarte.Abstract.Repository;
using Straßenkarte.Enitites;
using Straßenkarte.Enitites.ContextSınıfı;

namespace Straßenkarte.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
