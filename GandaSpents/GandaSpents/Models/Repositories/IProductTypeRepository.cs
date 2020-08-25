using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models
{
    public interface IProductTypeRepository
    {
        public IEnumerable<ProductType> GetAll();
        public ProductType GetById(int id);
        public IEnumerable<ProductType> GetByName(string name);
        public void CreateProductType(ProductType productType);
        public void UpdateProductType(ProductType productType);
        public void DeleteProductType(int id);


    }
}
