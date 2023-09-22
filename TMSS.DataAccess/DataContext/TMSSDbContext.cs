using Microsoft.EntityFrameworkCore;

namespace TMSS.DataAccess.DataContext
{
    public class TMSSDbContext : DbContext
    {
        public TMSSDbContext()
        {
        }

        public TMSSDbContext(DbContextOptions<TMSSDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new InvalidOperationException("Connectionstring is missing");
            }
        }
    }
}
