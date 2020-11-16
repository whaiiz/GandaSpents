using GandaSpents.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Sql
{
    public class ProductTypeRepository : IProductTypeRepository 
    {
        private readonly AppDbContext _dbContext; 

        public ProductTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(ProductType productType)
        {
            await _dbContext.ProductTypes.AddAsync(productType);
        }

        public async Task DeleteAsync(string id)
        {
            var productType = await GetByIdAsync(id);
            if (productType != null)
            {
                _dbContext.ProductTypes.Remove(productType);
            }
        }

        public void Update(ProductType productType)
        {
            var entity = _dbContext.ProductTypes.Attach(productType);
            entity.State = EntityState.Modified;
        }

        public IEnumerable<ProductType> GetAll()
        {
            return _dbContext.ProductTypes;
        }

        public async Task<ProductType> GetByIdAsync(string id)
        {
            return await _dbContext.ProductTypes.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> AlreadyExistsAsync(string name)
        {
            if (await _dbContext.ProductTypes.FirstOrDefaultAsync(p => p.Name == name) == null) return false;
            return true;
        }
    }
}
