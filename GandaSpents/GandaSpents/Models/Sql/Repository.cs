using GandaSpents.Controllers.Api;
using GandaSpents.Models.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Repositories
{
    public abstract class Repository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Create(Model model)
        {
            GetModel().Add(model);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var model = GetById(id);
            if (model != null) GetModel().Remove(model);
            _dbContext.SaveChanges();
        }

        public virtual IEnumerable<Model> GetAll()
        {
            return GetModel();
        }

        public virtual Model GetById(int id)
        {
            return GetAll().FirstOrDefault(m => m.Id == id);
        }

        public virtual void Update(Model model)
        {
            var entity = GetModel().Attach(model);
            entity.State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        // pq nao db set de model
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
