using StoreG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace StoreGWeb.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //With IdentityDbContext
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "RPG", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Action", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Sports", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Horror", DisplayOrder = 4 }
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
                    Price100 = 21,
                    CategoryId = 2,
                    ImageURL=""
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
                    Price100 = 31,
                    CategoryId = 3,
                    ImageURL = ""
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
                    Price100 = 29,
                    CategoryId = 2,
                    ImageURL = ""
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
                    Price100 = 20,
                    CategoryId = 3,
                    ImageURL = ""
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
                    Price100 = 26,
                    CategoryId = 2,
                    ImageURL = ""
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
                    Price100 = 20,
                    CategoryId = 2,
                    ImageURL = ""
                }
                    );

            modelBuilder.Entity<Company>().HasData(
               new Company
               {
                   Id = 1,
                   Name = "Bandai Namco",
                   StreetAddress = "123 Tech St",
                   City = "Tech City",
                   PostalCode = "123123",
                   State = "IL",
                   PhoneNumber = "6656456334"
               },
                new Company
                {
                    Id = 2,
                    Name = "From Software",
                    StreetAddress = "123 NYPD St",
                    City = "Tech2 City NYPD",
                    PostalCode = "123123",
                    State = "NY",
                    PhoneNumber = "3456456334"
                },
                new Company
                {
                    Id = 3,
                    Name = "Codemaster",
                    StreetAddress = "123 British St",
                    City = "British Tech City",
                    PostalCode = "123123",
                    State = "LND",
                    PhoneNumber = "1156379334"
                }
               );
        }
    }
}
