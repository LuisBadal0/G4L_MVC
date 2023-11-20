using StoreG.DataAccess.Repository.IRepository;
using StoreG.Models;
using StoreGWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreG.Models.ViewModels;

namespace StoreGWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _UnitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            //Get values from db to a variable
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //get all Products
            List<Product> objProductList = _UnitOfWork.Product.GetAll().ToList();

            return View(objProductList);
        }
        public IActionResult Upsert(int? id)
        {
            //TempData
            ProductVM productVM = new()
            {
                //get list projection EF Core
                CategoryList = _UnitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                //Update
                productVM.Product = _UnitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }

            //ViewData
            //ViewData["CategoryList"] = CategoryList;
            //asp-items="@(ViewData["CategoryList"] as Ienumerable<SelectListItem>)"

            //ViewBag.CategoryList = CategoryList;



        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Product.Add(productVM.Product);
                _UnitOfWork.Save();
                //Add notification to the user
                TempData["success"] = "Product Added!";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                productVM.CategoryList = _UnitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _UnitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? objcat = _UnitOfWork.Product.Get(u => u.Id == id);
            if (objcat == null)
            {
                return NotFound();
            }
            _UnitOfWork.Product.Remove(objcat);
            _UnitOfWork.Save();
            TempData["success"] = "Product Deleted!";
            return RedirectToAction("Index");
        }
    }
}
