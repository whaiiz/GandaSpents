using GandaSpents.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models
{
    public interface IProductTypeRepository : IRepository
    {
        public Boolean AlreadyExists(string name);

    }
}
