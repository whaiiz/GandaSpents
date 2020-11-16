using GandaSpents.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Sql
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);          
        }

        public async Task DeleteAsync(string id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
            }
        }

        public void Update(Product product)
        {
            var entity = _dbContext.Products.Attach(product);
            entity.State = EntityState.Modified;
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products;
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
