using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GandaSpents.Models;
using GandaSpents.Models.Repositories;
using GandaSpents.Models.Sql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GandaSpents.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpentController : ApiController<Spent>
    {
        private readonly ISpentRepository _spentRepository;
        
        public SpentController(ISpentRepository spentRepository, LinkGenerator linkGenerator, IMapper mapper): base(spentRepository,linkGenerator,mapper)
        {
            _spentRepository = spentRepository;   
        }

        public override IActionResult Create(Spent model)
        {
            try
            {
                if (model.ProductId == 0) return BadRequest("Please, enter a valid product id.");
                if (model.SpentEntityId == 0) return BadRequest("Please, enter a Spent entity id.");
                if (model.Price == 0) return BadRequest("Please, enter a price.");
                if (model.Amount == 0) return BadRequest("Please, enter a amount.");

                _spentRepository.Create(model);
                var url = LinkGenerator.GetPathByAction(HttpContext, "GetById", values: new { id = model.Id });

                return Created(url, model);

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Did you enter a valid product type id?");
            }
        }

        public override IActionResult Put(int id, Spent model)
        {
            try
            {
                Spent spent = (Spent)_spentRepository.GetById(id);

                if (spent == null) return BadRequest("Id not found");

                if (model.ProductId == 0) return BadRequest("Please, enter a valid product id.");
                if (model.SpentEntityId == 0) return BadRequest("Please, enter a Spent entity id.");
                if (model.Price == 0) return BadRequest("Please, enter a price.");
                if (model.Amount == 0) return BadRequest("Please, enter a amount.");

                spent = Mapper.Map(model, spent);
                _spentRepository.Update(spent);

                return Ok();

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Did you enter a valid product type id?");
            }
        }
    }
}
