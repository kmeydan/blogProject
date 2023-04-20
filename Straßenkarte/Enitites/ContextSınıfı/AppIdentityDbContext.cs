using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Straßenkarte.Enitites.ContextSınıfı
{
    public class AppIdentityDbContext: IdentityDbContext<AppUser,AppRole,string>
	{
		public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
		{

		}
	}
}
