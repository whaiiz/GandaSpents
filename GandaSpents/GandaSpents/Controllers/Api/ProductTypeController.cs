using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GandaSpents.Models;
using GandaSpents.Models.Sql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GandaSpents.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ApiController<ProductType>
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeController(IProductTypeRepository productTypeRepository, LinkGenerator linkGenerator, IMapper mapper) : base (productTypeRepository,linkGenerator,mapper)
        {
            _productTypeRepository = productTypeRepository;
        }

         public override IActionResult Create(ProductType model)
         {
            try { 

                if(model.Name == null) return BadRequest("Please, enter a name for your product.");

                _productTypeRepository.Create(model);
                var url = LinkGenerator.GetPathByAction(HttpContext, "GetById", values: new { id = model.Id });

                return Created(url, model);

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Did you enter a valid product type id?");
            }
         }

        public override IActionResult Put(int id, ProductType model)
        {
            try
            {
                ProductType product = (ProductType)_productTypeRepository.GetById(id);

                if (product == null) return BadRequest("Id not found");

                if (model.Name == null) return BadRequest("Please, enter a name for your product.");

                product = Mapper.Map(model, product);
                _productTypeRepository.Update(product);

                return Ok();

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Did you enter a valid product type id?");
            }
        }
    }
}
    