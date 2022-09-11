using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
//using DAL.Entities;

namespace DAL.Repository
{

    public class TestIAContext : DbContext
    {
        public TestIAContext()
        {

        }
        public TestIAContext(DbContextOptions<TestIAContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestIADB");

            base.OnConfiguring(optionsBuilder);
        }

    }



}
