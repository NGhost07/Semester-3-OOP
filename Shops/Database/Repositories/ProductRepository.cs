using System.Collections.Generic;
using Shops.Database.Infrastructure;
using Shops.Model;

namespace Shops.Database.Repositories
{
    public class ProductRepository
        : Repository<Product>, IProductRepository
    {
        public Product FindProduct(Shop shop, string productName)
        {
            foreach (Product product in Items)
            {
                if (product.Name == productName && product.Shop == shop)
                {
                    return product;
                }
            }

            return null;
        }

        public List<Product> FindProducts(string name, int amount)
        {
            var products = new List<Product>();
            foreach (Product product in Items)
            {
                if (product.Name == name && product.Amout > amount)
                {
                    products.Add(product);
                }
            }

            return products;
        }
    }
}