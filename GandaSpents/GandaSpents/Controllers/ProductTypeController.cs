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
            var productTypeViewModel = new ProductTypeViewModel()
            {
                ProductTypes = _productTypeRepository.GetAll()
            };

            return View(productTypeViewModel);
        }

        public async Task<IActionResult> CreateOrEdit(string id)
        {
            var productType = await _productTypeRepository.GetByIdAsync(id);
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
        public async Task<IActionResult> NewProductType(ProductType productType)
        {
            if (await _productTypeRepository.AlreadyExistsAsync(productType.Name))
            {
                TempData["message"] = "Product Type with that name already exists!";
                return RedirectToAction("CreateOrEdit",  new { productType });
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateOrEdit", new { productType });
            }

            productType.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            productType.Id = Guid.NewGuid().ToString();
            await _productTypeRepository.CreateAsync(productType);
            await _productTypeRepository.SaveChangesAsync();
            TempData["message"] = "Product Type created!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditProductType(ProductType productType)
        {
            _productTypeRepository.Update(productType);
            await _productTypeRepository.SaveChangesAsync();
            TempData["message"] = "Product was edited with success!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _productTypeRepository.DeleteAsync(id);
            await _productTypeRepository.SaveChangesAsync();
            TempData["message"] = "Product type deleted!";
            return RedirectToAction("Index");
        }


    }
}
