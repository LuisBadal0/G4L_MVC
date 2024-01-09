using StoreG.DataAccess.Repository.IRepository;
using StoreG.Models;
using StoreGWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreG.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using StoreG.Utility;

namespace StoreGWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {

        private readonly IUnitOfWork _UnitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            //Get values from db to a variable
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            //get all Companies

            List<Company> objCompanyList = _UnitOfWork.Company.GetAll().ToList();

            return View(objCompanyList);
        }
        public IActionResult Upsert(int? id)
        {

            if (id == null || id == 0)
            {
                //Create
                return View(new Company());
            }
            else
            {
                //Update

                Company Companyobj = _UnitOfWork.Company.Get(u => u.Id == id);
                return View(Companyobj);

            }

            //ViewData
            //ViewData["CategoryList"] = CategoryList;
            //asp-items="@(ViewData["CategoryList"] as Ienumerable<SelectListItem>)"

            //ViewBag.CategoryList = CategoryList;



        }
        [HttpPost]

        public IActionResult Upsert(Company Companyobj)
        {
            if (ModelState.IsValid)
            {
                if (Companyobj.Id == 0)
                {
                    _UnitOfWork.Company.Add(Companyobj);
                }
                else
                {
                    _UnitOfWork.Company.Update(Companyobj);
                }

                _UnitOfWork.Save();
                //Add notification to the user
                TempData["success"] = "Company Added!";
                return RedirectToAction("Index", "Company");
            }
            else
            {

                return View(Companyobj);

            }
        }
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll(int id)
        {

            List<Company> objCompanyList = _UnitOfWork.Company.GetAll().ToList();

            return Json(new { data = objCompanyList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var companyToBeDeleted = _UnitOfWork.Company.Get(u => u.Id == id);

            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _UnitOfWork.Company.Remove(companyToBeDeleted);
            _UnitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully" });
        }
        #endregion
    }
}
