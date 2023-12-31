﻿using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var productList = _unitOfWork.ProductRepository.GetAll("Category").OrderBy(x => x.Title).ToList();
            return View(productList);
        }

        public IActionResult Upsert(int? id)
        {
            var model = new ProductViewModel
            {
                Product = new Product(),
                CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).OrderBy(x => x.Text).ToList()
            };
            if (id == null || id == 0)
            {
                // Create
                return View(model);
            }
            else
            {
                // Update
                model.Product = _unitOfWork.ProductRepository.Get(x => x.Id == id);
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductViewModel model, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                if (image != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!string.IsNullOrEmpty(model.Product.ImageUrl))
                    {
                        // Delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, model.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }

                    model.Product.ImageUrl = @"\images\product\" + fileName;
                }

                if (model.Product.Id == 0)
                {
                    _unitOfWork.ProductRepository.Add(model.Product);
                }
                else
                {
                    _unitOfWork.ProductRepository.Update(model.Product);
                }
                
                _unitOfWork.ProductRepository.SaveChanges();
                TempData["Success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                model.CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).OrderBy(x => x.Text).ToList();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.ProductRepository.SaveChanges();
                TempData["Success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.ProductRepository.GetAll("Category").OrderBy(x => x.Title).ToList();
            return Json(new { data = productList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var product = _unitOfWork.ProductRepository.Get(x => x.Id == id);
            if (product == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            if (!string.IsNullOrEmpty(product.ImageUrl)) 
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _unitOfWork.ProductRepository.Remove(product);
            _unitOfWork.SaveChanges();

            return Json(new { success = true, message = "Product deleted successfully" });
        }
        #endregion
    }
}
