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
    public class SpentController : ApiController<Spent>
    {
        private readonly SpentRepository _spentRepository;
        
        public SpentController(SpentRepository spentRepository, LinkGenerator linkGenerator, IMapper mapper): base(spentRepository,linkGenerator,mapper)
        {
            _spentRepository = spentRepository;   
        }
    }
}
