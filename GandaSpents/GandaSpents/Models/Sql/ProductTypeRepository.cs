using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Sql
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;        
        }
        public void CreateProductType(ProductType productType)
        {
            _appDbContext.ProductTypes.Add(productType);
            _appDbContext.SaveChanges();
        }

        public void DeleteProductType(int id)
        {
            var productionType = GetById(id);
            if (productionType != null) _appDbContext.Remove(productionType);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<ProductType> GetAll()
        {
            return _appDbContext.ProductTypes;
        }

        public ProductType GetById(int id)
        {
            return _appDbContext.ProductTypes.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ProductType> GetByName(string name)
        {
            return _appDbContext.ProductTypes.Where(p => p.Name == name);
        }

        public void UpdateProductType(ProductType productType)
        {
            _appDbContext.Entry(productType).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }
    }
}
