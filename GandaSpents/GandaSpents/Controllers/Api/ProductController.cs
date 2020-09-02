﻿using System;
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

    }
}
