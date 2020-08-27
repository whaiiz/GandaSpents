using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Repositories
{
    public interface IRepository
    {
        public IEnumerable<Model> GetAll();
        public Model GetById(int id);
        public void Create(Model model);
        public void Update(Model model);
        public void Delete(int id);
    }
}
