using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GandaSpents.Models;
using GandaSpents.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GandaSpents.Controllers
{
    public class SpentEntityController : Controller
    {
        private readonly ISpentEntityRepository _spentEntityRepository;

        public SpentEntityController(ISpentEntityRepository spentEntityRepository)
        {
            _spentEntityRepository = spentEntityRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<SpentEntity> spentEntities = (IEnumerable<SpentEntity>)_spentEntityRepository.GetAll();
            return View(spentEntities);
        }

        public async Task<IActionResult> CreateOrEdit(string id)
        {
            var spentEntity = await _spentEntityRepository.GetByIdAsync(id);

            if(spentEntity == null)
            {
                spentEntity = new SpentEntity();
            }

            return View(spentEntity);
        }

        public async Task<IActionResult> NewSpentEntity(SpentEntity spentEntity)
        {
            if (await _spentEntityRepository.AlreadyExistsAsync(spentEntity.Name))
            {
                TempData["message"] = "This name already exist please choose another!";
                return RedirectToAction("CreateOrEdit");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateOrEdit", new {SpentEntity = spentEntity});
            } 

            await _spentEntityRepository.CreateAsync(spentEntity);
            TempData["message"] = "Spent Entity created!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditSpentEntity(SpentEntity spentEntity)
        {
            if (await _spentEntityRepository.AlreadyExistsAsync(spentEntity.Name))
            {
                TempData["message"] = "This name already exist please choose another!";
                return RedirectToAction("CreateOrEdit");
            }

            _spentEntityRepository.Update(spentEntity);
            TempData["message"] = "Spent Entity Updated";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            _spentEntityRepository.Delete(id);
            TempData["message"] = "Spent Entity Deleted";
            return RedirectToAction("Index");
        }
    }
}
