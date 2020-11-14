using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GandaSpents.Models;
using GandaSpents.Models.Repositories;
using GandaSpents.Models.Sql;
using GandaSpents.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GandaSpents.Controllers
{
    public class SpentController : Controller
    {
        private readonly ISpentRepository _spentRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISpentEntityRepository _spentEntityRepository;

        public SpentController(ISpentRepository spentRepository, IProductRepository productRepository, ISpentEntityRepository spentEntityRepository)
        {
            _spentRepository = spentRepository;
            _productRepository = productRepository;
            _spentEntityRepository = spentEntityRepository;
        }

        public IActionResult Index()
        {
            var spentList = _spentRepository.GetAll();
            return View(spentList);
        }

        public IActionResult CreateOrEdit(int id)
        {      
            SpentViewModel spentViewModel = new SpentViewModel
            {
                SpentEntities = (IEnumerable<SpentEntity>)_spentEntityRepository.GetAll(),
                Products = (IEnumerable<Product>)_productRepository.GetAll()
            };

            var spent = _spentRepository.GetById(id);

            if (spent != null) {
                spentViewModel.Spent = (Spent)spent;
            }
            else {
                spentViewModel.Spent = new Spent()
                {
                    Amount = 1,
                    Date = DateTime.Now
                };
            };

            return View(spentViewModel);
        }

        [HttpPost]
        public IActionResult NewSpent(Spent spent)  
        {
            spent.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid) {
                _spentRepository.Create(spent);
                TempData["successMessage"] = "Spent Created!";
                return RedirectToAction("Index");
            }

            return RedirectToAction("CreateOrEdit");

        }

        public IActionResult Delete(int id)
        {
            _spentRepository.Delete(id);
            TempData["successMessage"] = "Spent Deleted!";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Spent spent)
        {
            if (ModelState.IsValid)
            {
                spent.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _spentRepository.Update(spent);
                TempData["successMessage"] = "Spent Modified!";
                return RedirectToAction("Index");
            }

            return RedirectToAction("CreateOrEdit");

        }
    }
}
