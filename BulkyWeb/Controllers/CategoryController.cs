using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            //Get values from db to a variable
            _db = db;
        }
        public IActionResult Index()
        {
            //get all categories
            List<Category> objCategoryList = _db.Categories.ToList();
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
                _db.Categories.Add(objcat);
                _db.SaveChanges();
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
            Category? categoryFromDb = _db.Categories.Find(id);
            //Other ways to get value
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
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
                _db.Categories.Update(objcat);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
