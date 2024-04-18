﻿using StoreG.DataAccess.Repository.IRepository;
using StoreG.Models;
using StoreGWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreG.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using StoreG.Utility;
using Microsoft.EntityFrameworkCore;

namespace StoreGWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            //Get values from db to a variable
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll(int id)
        {
            //Get All Users
            List<ApplicationUser> objUserList = _db.ApplicationUsers.Include(u => u.Company).ToList();

            //Get userRoles and Roles
            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var user in objUserList)
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;

                if(user.Company == null)
                {
                    user.Company = new() { Name = "" };
                }
            }

            return Json(new { data = objUserList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            
            return Json(new { success = true, message = "Deleted successfully" });
        }
        #endregion
    }
}
