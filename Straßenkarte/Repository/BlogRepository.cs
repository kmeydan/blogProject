using Microsoft.EntityFrameworkCore;
using Straßenkarte.Abstract;
using Straßenkarte.Abstract.Repository;
using Straßenkarte.Enitites;
using Straßenkarte.Enitites.ContextSınıfı;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Straßenkarte.Repository
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
		

		public BlogRepository(AppDbContext dbContext) : base(dbContext)
        {
			
		}


		

		
	}
}
