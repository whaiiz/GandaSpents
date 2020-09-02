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
    public abstract class ApiController<M> : ControllerBase where M : Model
    {
        private readonly IRepository _repository;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public ApiController(IRepository repository, LinkGenerator linkGenerator, IMapper mapper)
        {
            _repository = repository;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(M model)
        {
            // if (productType.Name == null) return BadRequest("You need to send a name");
            _repository.Create(model);
            var url = _linkGenerator.GetPathByAction(HttpContext, "GetById", values: new { id = model.Id });
            return Created(url, model);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, M model)
        {
            M modelToFind = (M) _repository.GetById(id);

            if (modelToFind == null) return BadRequest("Id not found");

            modelToFind = _mapper.Map(model, modelToFind);
           
            _repository.Update(modelToFind);
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var model = _repository.GetById(id);
            _repository.Delete(id);
            if (model == null) return BadRequest("You need to send an id");
            return Ok();

        }
    }
}
