using kaShop.Models;
using Microsoft.EntityFrameworkCore;

namespace kaShop.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=Ka_Shop;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
              new Category { Id=1,Name="Mobile"},
              new Category { Id = 2, Name = "Tablets" },
              new Category { Id = 3, Name = "Laptops" }
            );
        }
    }
}
