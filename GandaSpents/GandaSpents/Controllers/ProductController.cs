using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GandaSpents.Models;
using GandaSpents.Models.Repositories;
using GandaSpents.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GandaSpents.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductController(IProductRepository productRepository, IProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        public async Task<IActionResult> CreateOrEdit(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if(product == null) product = new Product();
            
            var productViewModel = new ProductViewModel()
            {
                Product = product,
                ProductTypes = _productTypeRepository.GetAll()
            };

            return View(productViewModel);
        }

        public async Task<IActionResult> NewProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                var productViewModel = new ProductViewModel()
                {
                    Product = product,
                    ProductTypes = _productTypeRepository.GetAll()
                };

                return RedirectToAction("CreateOrEdit", new {ProductViewModel = productViewModel});
            }

            await _productRepository.CreateAsync(product);
            TempData["message"] = "Product created with success";

            return RedirectToAction("Index");
        }

        public IActionResult EditProduct(Product product)
        {
            _productRepository.Update(product);
            TempData["message"] = "Product was edited with success!";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            _productRepository.Delete(id);
            TempData["message"] = "Product deleted!";
            return RedirectToAction("Index");
        }

    }
}
