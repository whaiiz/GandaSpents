using System;
using AutoMapper;
using GandaSpents.Models;
using GandaSpents.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GandaSpents.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiSpentEntityController : ApiController<SpentEntity>
    {
        private readonly ISpentEntityRepository _spentEntityRepository;

        public ApiSpentEntityController(ISpentEntityRepository spentEntityRepository, LinkGenerator linkGenerator, IMapper mapper) : base(spentEntityRepository,linkGenerator, mapper)
        {
            _spentEntityRepository = spentEntityRepository;
        }

        public override IActionResult Create(SpentEntity model)
        {
            try
            {
                if (model.Name == null) return BadRequest("Please, enter a name for the spent entity.");

                _spentEntityRepository.Create(model);
                var url = LinkGenerator.GetPathByAction(HttpContext, "GetById", values: new { id = model.Id });

                return Created(url, model);

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Did you enter a valid product type id?");
            }
        }

        public override IActionResult Put(int id, SpentEntity model)
        {
            try
            {
                SpentEntity spentEntity = (SpentEntity)_spentEntityRepository.GetById(id);

                if (spentEntity == null) return BadRequest("Id not found");

                if (model.Name == null) return BadRequest("Please, enter a name for your product.");

                spentEntity = Mapper.Map(model, spentEntity);
                _spentEntityRepository.Update(spentEntity);

                return Ok();

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Did you enter a valid product type id?");
            }
        }

    }
}
