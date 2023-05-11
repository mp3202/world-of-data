using Microsoft.EntityFrameworkCore;

namespace world_of_data.Models
{
	public class WoWClassDbContext : DbContext
	{
		public WoWClassDbContext (DbContextOptions<WoWClassDbContext> options)
			: base(options)
		{
		}

		public DbSet<Character> Character {get; set;} = default!;
		public DbSet<Character> Characters {get; set;} = default!;

		public DbSet<WoWClass> WoWClass {get; set;} = default!;
	}
}