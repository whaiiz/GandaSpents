using GandaSpents.Models;
using GandaSpents.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.ViewComponents
{
    public class SpentCountViewComponent : ViewComponent
    {
        private readonly ISpentRepository _spentRepository;

        public SpentCountViewComponent(ISpentRepository spentRepository)
        {
            _spentRepository = spentRepository;
        }

        public IViewComponentResult Invoke()
        {
            var spents = _spentRepository.GetMonthSpents();
            double moneySpent = 0;

            foreach(var spent in spents)
            {
                moneySpent += spent.Price * spent.Amount;
            }
            return View(moneySpent);
        }
    }
}
