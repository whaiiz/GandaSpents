using GandaSpents.Controllers.Api;
using GandaSpents.Models.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Repositories
{
    public abstract class Repository<M> : IRepository where M : Model
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<M> _models;
        
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _models = GetModel();
        }
        
        public virtual void Create(Model model)
        {
            _models.Add((M)model);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(int id)
        {

            if(this is IProductTypeRepository)
            {
                var model = GetById(id);
                if (model != null)
                {
                    _models.Remove((M)model);
                    _dbContext.SaveChanges();
                }
            }

        }

        public virtual IEnumerable<Model> GetAll()
        {
            return _models;
        }

        public virtual Model GetById(int id)
        {
            return _models.FirstOrDefault(m => m.Id == id);
        }

        public virtual void Update(Model model)
        {
            var entity = _models.Attach((M) model);
            entity.State = EntityState.Modified;
            _dbContext.SaveChanges();
        }


        // pq nao db set de model, pq nao consegue converter o dbset model para dbsd
        private dynamic GetModel()
        {
            if (this is IProductTypeRepository) return _dbContext.ProductTypes;
            if (this is ISpentEntityRepository) return _dbContext.SpentEntities;
            if (this is ISpentRepository) return _dbContext.Spents;
            if (this is IProductRepository)  return _dbContext.Products;

            return null;
        }
    } 
}
