using System.Data.Entity;

namespace DiceWorld.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DiceWorld")
        {
            Configuration.LazyLoadingEnabled = false; 
        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<BoardGameStats> BoardGameStats { get; set; }
        public DbSet<Tag> Tags { get; set; } 
        public DbSet<TagDefinition> TagDefinitions { get; set; }

        public System.Data.Entity.DbSet<DiceWorld.Models.Cart> Carts { get; set; } 
    }
}
