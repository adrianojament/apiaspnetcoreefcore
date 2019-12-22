using System.Collections.Generic;
using ApiAspnetCoreEfCore.Data;
using ApiAspnetCoreEfCore.Models;

namespace ApiAspnetCoreEfCore.Repositories
{
    public class ProductRepository
    {
        private readonly StoreDataContext _datacontext;

        public ProductRepository(StoreDataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public IEnumerable<Product> Get()
        {
            return _datacontext.Products;
        }

        public void Create(Product product)
        {
            _datacontext.Products.Add(product);
            _datacontext.SaveChanges();
        }
    }
}