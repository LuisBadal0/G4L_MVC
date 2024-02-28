using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreG.Models;
using StoreG.Utility;
using StoreGWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreG.DataAccess.DbInicializer
{
    internal class DbInitializer : IDbInitializer
    {
        //Dependecy Injection
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }
        public void Initialize()
        {

            //Migration if not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }catch (Exception ex) { }
            //Create roles if not created
            if(!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();

                //Roles not created, create admin user too
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@a.aa",
                    Email = "admin@a.aa",
                    Name = "admin admin",
                    PhoneNumber = "112121312",
                    StreetAddress = "test admin Ave",
                    Country = "Portugal",
                    PostalCode = "12345",
                    City = "Lisbon"
                }, "123ASD_").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@a.aa");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }

            return;
        }
    }
}
