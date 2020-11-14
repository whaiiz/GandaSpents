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

        public IActionResult CreateOrEdit(int id)
        {
            var product = _productRepository.GetById(id);

            if(product == null) product = new Product();
            
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Product = (Product)product,
                ProductTypes = (IEnumerable<ProductType>)_productTypeRepository.GetAll()
            };

            return View(productViewModel);
        }

        public IActionResult NewProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                ProductViewModel productViewModel = new ProductViewModel()
                {
                    Product = product,
                    ProductTypes = (IEnumerable<ProductType>)_productTypeRepository.GetAll()
                };

                return RedirectToAction("CreateOrEdit", new {ProductViewModel = productViewModel});
            }

            _productRepository.Create(product);
            TempData["message"] = "Product created with success";

            return RedirectToAction("Index");
        }

        public IActionResult EditProduct(Product product)
        {
            _productRepository.Update(product);
            TempData["message"] = "Product was edited with success!";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            TempData["message"] = "Product deleted!";
            return RedirectToAction("Index");
        }

    }
}
