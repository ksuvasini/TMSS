﻿using Microsoft.EntityFrameworkCore;
using TMSS.Domain.Entities;
using TMSS.Web.Models;

namespace TMSS.DataAccess.DataContext
{
    public class TMSSDbContext : DbContext
    {
        public TMSSDbContext()
        {
        }

        public TMSSDbContext(DbContextOptions<TMSSDbContext> options) : base(options) { }
        public virtual DbSet<Procedure> Procedure { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Clinic> Clinic { get; set; }
        public virtual DbSet<Complication> Complication { get; set; }
        public virtual DbSet<Surgeon> Surgeon { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=TMSS;Trusted_Connection=True;");  // put your connection string
            }
        }
    }
}
