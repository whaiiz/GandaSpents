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
    public class SpentEntityController : ApiController<SpentEntity>
    {
        private readonly ISpentEntityRepository _spentEntityRepository;

        public SpentEntityController(ISpentEntityRepository spentEntityRepository, LinkGenerator linkGenerator, IMapper mapper) : base(spentEntityRepository,linkGenerator, mapper)
        {
            _spentEntityRepository = spentEntityRepository;

        }

    }
}
