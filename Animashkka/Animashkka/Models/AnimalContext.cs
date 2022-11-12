using Microsoft.EntityFrameworkCore;

namespace Animashkka.Models
{
    public class AnimalContext : DbContext
    {
        public AnimalContext()
        {
        }

        public AnimalContext(DbContextOptions<AnimalContext> options)
            : base(options)
        {
        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Animashkka;Trusted_Connection=True;");
            
        }
        
    }
    
}
