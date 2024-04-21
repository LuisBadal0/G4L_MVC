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
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            //Get values from db to a variable
            _UnitOfWork = unitOfWork;
            _WebHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            //get all Products
            List<Product> objProductList = _UnitOfWork.Product.GetAll(includeProperties: "Category").ToList();

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
                productVM.Product = _UnitOfWork.Product.Get(u => u.Id == id, includeProperties:"ProductImages");
                return View(productVM);
            }

            //ViewData
            //ViewData["CategoryList"] = CategoryList;
            //asp-items="@(ViewData["CategoryList"] as Ienumerable<SelectListItem>)"

            //ViewBag.CategoryList = CategoryList;



        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, List<IFormFile?> files)
        {
            if (ModelState.IsValid)
            {

                if (productVM.Product.Id == 0)
                {
                    _UnitOfWork.Product.Add(productVM.Product);
                }
                else
                {
                    _UnitOfWork.Product.Update(productVM.Product);
                }

                _UnitOfWork.Save();

                string wwwRootPath = _WebHostEnvironment.WebRootPath;
                if (files != null)
                {
                    foreach (IFormFile file in files)
                    {
                        //Get random query filename
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        //Get productId to name a folder
                        string productPath = @"images\products\product-" + productVM.Product.Id;
                        //Get location of the folder
                        string finalPath = Path.Combine(wwwRootPath, productPath);

                        if (!Directory.Exists(finalPath))
                        {
                            Directory.CreateDirectory(finalPath);
                        }

                        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                        {
                            //Copy the file to the folder
                            file.CopyTo(fileStream);
                        }

                        ProductImage productImage = new()
                        {
                            ImageUrl =@"\" + productPath+ @"\" + fileName,
                            ProductId = productVM.Product.Id,

                        };

                        if(productVM.Product.ProductImages  == null)
                        {
                            productVM.Product.ProductImages = new List<ProductImage>();
                        }

                        productVM.Product.ProductImages.Add(productImage);

                    }
                    _UnitOfWork.Product.Update(productVM.Product);
                    _UnitOfWork.Save();
                }

                //Add notification to the user
                TempData["success"] = "Product Added/Updated!";
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

        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _UnitOfWork.ProductImage.Get(u  => u.Id == imageId);
            int productId = imageToBeDeleted.ProductId;
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    
                    var oldImagePath = Path.Combine(_WebHostEnvironment.WebRootPath, imageToBeDeleted.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                _UnitOfWork.ProductImage.Remove(imageToBeDeleted);
                _UnitOfWork.Save();

                TempData["success"] = "Deleted Successfully!";
            }

            return RedirectToAction(nameof(Upsert), new {id= productId });
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {

            List<Product> objProductList = _UnitOfWork.Product.GetAll(includeProperties: "Category").ToList();

            return Json(new { data = objProductList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var productToBeDeleted = _UnitOfWork.Product.Get(u => u.Id == id);

            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            //Delete old image
            //var oldImagePath = Path.Combine(_WebHostEnvironment.WebRootPath, productToBeDeleted.ImageURL.TrimStart('\\'));

            //if (System.IO.File.Exists(oldImagePath))
            //{
            //    System.IO.File.Delete(oldImagePath);
            //}

            //Get productId to name a folder
            string productPath = @"images\products\product-" + id;
            //Get location of the folder
            string finalPath = Path.Combine(_WebHostEnvironment.WebRootPath, productPath);

            if (!Directory.Exists(finalPath))
            {
                //Get all files images path
                string[] filePaths = Directory.GetFiles(finalPath);
                //Delete each image
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }
                Directory.Delete(finalPath);
            }


            _UnitOfWork.Product.Remove(productToBeDeleted);
            _UnitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully" });
        }
        #endregion
    }
}
