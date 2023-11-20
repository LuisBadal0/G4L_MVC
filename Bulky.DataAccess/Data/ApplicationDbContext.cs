using StoreG.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreGWeb.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "RPG", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Action", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Sports", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Horror", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "Elden Ring",
                    Description = "Elden Ring Description",
                    Developer = "FromSoftware, Inc",
                    Publisher = "BANDAI NAMCO Entertainment, FromSoftware, Inc ",
                    ListPrice = 31,
                    Price50 = 26,
                    Price100 = 21
                },
                new Product
                {
                    Id = 2,
                    ProductName = "F1 23",
                    Description = "F1 23 Description",
                    Developer = "Codemasters",
                    Publisher = "Electronic Arts",
                    ListPrice = 41,
                    Price50 = 36,
                    Price100 = 31
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Final Fantasy VII - Intergrade",
                    Description = "Final Fantasy VII - Intergrade Description",
                    Developer = "Square Enix",
                    Publisher = "Square Enix",
                    ListPrice = 39,
                    Price50 = 34,
                    Price100 = 29
                },
                new Product
                {
                    Id = 4,
                    ProductName = "Resident Evil 4 - Remake",
                    Description = "Resident Evil 4 - Remake Description",
                    Developer = "CAPCOM Co., Ltd.",
                    Publisher = "CAPCOM Co., Ltd.",
                    ListPrice = 30,
                    Price50 = 25,
                    Price100 = 20
                },
                new Product
                {
                    Id = 5,
                    ProductName = "Lies of P",
                    Description = "Lies of P Description",
                    Developer = "NEOWIZ",
                    Publisher = "NEOWIZ",
                    ListPrice = 36,
                    Price50 = 31,
                    Price100 = 26
                },
                new Product
                {
                    Id = 6,
                    ProductName = "Risk of Rain Returns",
                    Description = "Risk of Rain Returns Description",
                    Developer = "Hopoo Games",
                    Publisher = "Gearbox Publishing",
                    ListPrice = 30,
                    Price50 = 25,
                    Price100 = 20
                }
                    );
        }
    }
}
