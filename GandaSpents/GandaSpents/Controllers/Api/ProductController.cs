using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ProductController : ApiController<Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository, LinkGenerator linkGenerator, IMapper mapper): base(productRepository,linkGenerator,mapper)
        {
            _productRepository = productRepository;
            
        }

        public override IActionResult Create(Product model)
        {
            try { 

                if(model.Name == null) return BadRequest("Please, enter a name for your product.");

                _productRepository.Create(model);
                var url = LinkGenerator.GetPathByAction(HttpContext, "GetById", values: new { id = model.Id });

                return Created(url, model);

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Did you enter a valid product type id?");
            }
        }

        public override IActionResult Put(int id, Product model)
        {
            try
            {
                Product product = (Product)_productRepository.GetById(id);

                if (product == null) return BadRequest("Id not found");

                if (model.Name == null) return BadRequest("Please, enter a name for your product.");

                product = Mapper.Map(model, product);
                _productRepository.Update(product);

                return Ok();

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Did you enter a valid product type id?");
            }
        }

    }
}
