
using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext: DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "labtop", Description = "laptop " },

                new Category { CategoryId = 2, Name = "Mobile", Description = "Mobile Phones" },
                new Category { CategoryId = 3, Name = "Tablet", Description = "Tablets" },
                new Category { CategoryId = 4, Name = "Accessories", Description = "Mobile Accessories" }
                );
        }
    }
}
