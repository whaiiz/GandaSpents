using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Repositories
{
    public interface ISpentEntityRepository : IRepository
    {
        public Boolean AlreadyExists(string name);
    }
}
