using System.Collections.Generic;
using Shops.Model;

namespace Shops.Database.Infrastructure
{
    public interface IProductRepository : IRepository<Product>
    {
        Product FindProduct(Shop shop, string productName);
        public List<Product> FindProducts(string name, int amount);
    }
}