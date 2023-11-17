using StoreG.DataAccess.Repository.IRepository;
using StoreG.Models;
using StoreGWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace StoreGWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        
        private readonly IUnitOfWork _UnitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            //Get values from db to a variable
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //get all categories
            List<Category> objCategoryList = _UnitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category objcat)
        {
            //If Name is same value as DisplayOrder
            //if (objcat.Name.ToLower()==objcat.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The Display Order must be diferent from the Name");
            //}
            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Add(objcat);
                _UnitOfWork.Save();
                //Add notification to the user
                TempData["success"] = "Category Added!";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _UnitOfWork.Category.Get(u => u.Id == id);
            //Other ways to get value
            //Category? categoryFromDb1 = _categoryRepo.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _categoryRepo.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category objcat)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Update(objcat);
                _UnitOfWork.Save();
                TempData["success"] = "Category Updated!";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _UnitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? objcat = _UnitOfWork.Category.Get(u => u.Id == id);
            if (objcat == null)
            {
                return NotFound();
            }
            _UnitOfWork.Category.Remove(objcat);
            _UnitOfWork.Save();
            TempData["success"] = "Category Deleted!";
            return RedirectToAction("Index");
        }
    }
}
