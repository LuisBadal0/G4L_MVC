using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            //Get values from db to a variable
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            //get all categories
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
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
                _categoryRepo.Add(objcat);
                _categoryRepo.Save();
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
            Category? categoryFromDb = _categoryRepo.Get(u=>u.Id==id);
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
                _categoryRepo.Update(objcat);
                _categoryRepo.Save();
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
            Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? objcat = _categoryRepo.Get(u => u.Id == id);
            if (objcat == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(objcat);
            _categoryRepo.Save();
            TempData["success"] = "Category Deleted!";
            return RedirectToAction("Index");
        }
    }
}
