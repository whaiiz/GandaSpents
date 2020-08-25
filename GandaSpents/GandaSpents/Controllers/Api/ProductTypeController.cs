﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GandaSpents.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GandaSpents.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly LinkGenerator _linkGenerator;

        public ProductTypeController(IProductTypeRepository productionTypeRepository, LinkGenerator linkGenerator)
        {
            _productTypeRepository = productionTypeRepository;
            _linkGenerator = linkGenerator;
        }

        public IActionResult Get()
        {
            return Ok(_productTypeRepository.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_productTypeRepository.GetById(id));
        } 
        
        [HttpPost]
        public IActionResult Create(ProductType productType)
        {

            if (productType.Name == null) return BadRequest("You need to send a name");
            _productTypeRepository.CreateProductType(productType);

            var url = _linkGenerator.GetPathByAction(HttpContext, "GetById", values: new {id = productType.Id });

            return Created(url, productType);

        }
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, ProductType productType)
        {
            var productType2 = _productTypeRepository.GetById(id);

            if(productType2 == null) return BadRequest("Id not found");

            _productTypeRepository.UpdateProductType(productType);
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var productType = _productTypeRepository.GetById(id);
            if (productType == null) return BadRequest("You need to send an id");
            return Ok();

        }

    }
}
