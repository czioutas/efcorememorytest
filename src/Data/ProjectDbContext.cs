using efcorememorytest.Entities;
using Microsoft.EntityFrameworkCore;

namespace efcorememorytest.Data
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<TestModel> TestModels { get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nested2TestModel>().HasNoKey();
            modelBuilder.Entity<Nested3TestModel>().HasNoKey();
            modelBuilder.Entity<Nested4TestModel>().HasNoKey();
            modelBuilder.Entity<Nested5TestModel>().HasNoKey();
            modelBuilder.Entity<Nested6TestModel>().HasNoKey();
        }
    }
}