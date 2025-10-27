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
            optionsBuilder.UseSqlServer("Server=db29749.public.databaseasp.net; Database=db29749; User Id=db29749; Password=R?q92hB+xS%3; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
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
