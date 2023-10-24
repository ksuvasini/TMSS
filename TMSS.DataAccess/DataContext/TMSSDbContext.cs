using Microsoft.EntityFrameworkCore;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;



namespace TMSS.DataAccess.DataContext
{
    public class TMSSDbContext : DbContext
    {
        public TMSSDbContext()
        {
        }

        public TMSSDbContext(DbContextOptions<TMSSDbContext> options) : base(options)
        {
            //  this.Configuration.ProxyCreationEnabled = true;
        }
        public virtual DbSet<ProceduresClinic> ProceduresClinic { get; set; }
        public virtual DbSet<Procedure> Procedure { get; set; }

        public virtual DbSet<Clinic> Clinic { get; set; }
        public virtual DbSet<Complication> Complication { get; set; }
        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Surgeon> Surgeon { get; set; }

        // public virtual DbSet<Clinic> Clinic { get; set; }
        //   public virtual DbSet<Complication> Complication { get; set; }
        //  public virtual DbSet<Surgeon> Surgeon { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=LAPTOP-924MOEOG\\SQLEXPRESS;Database=TMSS;User ID=sa;Password=sa@123;Integrated Security=True;Trusted_Connection=True;Encrypt=False;");  // put your connection string
            }
        }
    }
}
