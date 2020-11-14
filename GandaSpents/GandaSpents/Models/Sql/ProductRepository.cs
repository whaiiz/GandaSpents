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
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task Create(Product product)
        {
            await _context.AddAsync(product);          
        }

        public async Task Delete(int id)
        {
            var product = await GetById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
        }

        public IEnumerable<Model> GetAll()
        {
            return _context.Products;
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
        }

        public virtual void Update(Product product)
        {
            var entity = _context.Products.Attach(product);
            entity.State = EntityState.Modified;
        }
    }
}
