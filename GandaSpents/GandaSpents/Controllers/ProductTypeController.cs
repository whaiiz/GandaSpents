using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GandaSpents.Models;
using GandaSpents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GandaSpents.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeController(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public IActionResult Index()
        {
            ProductTypeViewModel productTypeViewModel = new ProductTypeViewModel()
            {
                ProductTypes = (IEnumerable<ProductType>)_productTypeRepository.GetAll()
            };

            return View(productTypeViewModel);
        }

        public IActionResult CreateOrEdit(int id)
        {
            var productType = (ProductType)_productTypeRepository.GetById(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (productType == null)
            {
                productType = new ProductType() {
                    UserId = userId
                };
            }

            return View(productType);
        }

        [HttpPost]
        public IActionResult NewProductType(ProductType productType)
        {
            if (_productTypeRepository.AlreadyExists(productType.Name))
            {
                TempData["message"] = "Product Type with that name already exists!";
                return RedirectToAction("CreateOrEdit",  new { productType = productType });
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateOrEdit", new { productType = productType });
            }

            productType.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _productTypeRepository.Create(productType);
            TempData["message"] = "Product Type created!";
            return RedirectToAction("Index");
        }

        public IActionResult EditProductType(ProductType productType)
        {
            _productTypeRepository.Update(productType);
            TempData["message"] = "Product was edited with success!";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _productTypeRepository.Delete(id);
            TempData["message"] = "Product type deleted!";
            return RedirectToAction("Index");
        }


    }
}
