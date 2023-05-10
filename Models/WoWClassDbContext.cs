using Microsoft.EntityFrameworkCore;

namespace world_of_data.Models
{
	public class WoWClassDbContext : DbContext
	{
		public WoWClassDbContext (DbContextOptions<WoWClassDbContext> options)
			: base(options)
		{
		}
		// public DbSet<User> Users {get; set;} = default!;
		public DbSet<WoWClass> WoWClasses {get; set;} = default!;
	}
}