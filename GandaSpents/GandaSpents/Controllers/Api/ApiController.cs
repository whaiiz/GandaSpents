using System;
using AutoMapper;
using GandaSpents.Models;
using GandaSpents.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GandaSpents.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController<M> : ControllerBase where M : Model
    {
        private readonly IRepository _repository;
        protected readonly LinkGenerator LinkGenerator;
        protected readonly IMapper Mapper;

        public ApiController(IRepository repository, LinkGenerator linkGenerator, IMapper mapper)
        {
            _repository = repository;
            LinkGenerator = linkGenerator;
            Mapper = mapper;
        }

        public virtual IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");  
            }
        }

        [HttpGet("{id:int}")]
        public virtual IActionResult GetById(int id)
        {
            try
            {
                var model = _repository.GetById(id);
                if (model == null) return BadRequest("Id doesn't exist");
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }

        }

        [HttpPost]
        public virtual IActionResult Create(M model)
        {
            try
            {
                _repository.Create(model);
                var url = LinkGenerator.GetPathByAction(HttpContext, "GetById", values: new { id = model.Id });
                return Created(url, model);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        [HttpPut("{id:int}")]
        public virtual IActionResult Put(int id, M model)
        {
            try
            {
                M modelToFind = (M)_repository.GetById(id);

                if (modelToFind == null) return BadRequest("Id not found");

                modelToFind = Mapper.Map(model, modelToFind);

                _repository.Update(modelToFind);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }

        }

        [HttpDelete("{id:int}")]
        public virtual IActionResult Delete(int id)
        {
            try
            {
                var model = _repository.GetById(id);
                _repository.Delete(id);
                if (model == null) return BadRequest("You need to send a valid id");
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }

        }
    }
}
