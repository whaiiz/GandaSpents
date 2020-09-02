﻿using System;
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

    }
}
