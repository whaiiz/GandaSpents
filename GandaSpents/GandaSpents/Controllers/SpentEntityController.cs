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

        public IActionResult CreateOrEdit(int id)
        {
            var spentEntity = _spentEntityRepository.GetById(id);

            if(spentEntity == null)
            {
                spentEntity = new SpentEntity();
            }

            return View(spentEntity);
        }

        public IActionResult NewSpentEntity(SpentEntity spentEntity)
        {
            if (_spentEntityRepository.AlreadyExists(spentEntity.Name))
            {
                TempData["message"] = "This name already exist please choose another!";
                return RedirectToAction("CreateOrEdit");
            }

            /*    if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateOrEdit", new {SpentEntity = spentEntity});
            } */

            _spentEntityRepository.Create(spentEntity);
            TempData["message"] = "Spent Entity created!";
            return RedirectToAction("Index");
        }

        public IActionResult EditSpentEntity(SpentEntity spentEntity)
        {
            if (_spentEntityRepository.AlreadyExists(spentEntity.Name))
            {
                TempData["message"] = "This name already exist please choose another!";
                return RedirectToAction("CreateOrEdit");
            }

            _spentEntityRepository.Update(spentEntity);
            TempData["message"] = "Spent Entity Updated";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _spentEntityRepository.Delete(id);
            TempData["message"] = "Spent Entity Deleted";
            return RedirectToAction("Index");
        }
    }
}
