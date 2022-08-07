using System.Collections.Generic;
using Shops.Common;
using Shops.Database.Infrastructure;
using Shops.Database.Repositories;
using Shops.Model;

namespace Shops.Service
{
    public class ShopsService : IShopsService
    {
        private ICustomerRepository _customerRepository;
        private IShopRepository _shopRepository;
        private IProductRepository _productRepository;
        private IBillRepository _billRepository;

        public ShopsService()
        {
            _customerRepository = new CustomerRepository();
            _shopRepository = new ShopRepository();
            _productRepository = new ProductRepository();
            _billRepository = new BillRepository();
        }

        public Customer AddCustomer(string name, int balance)
        {
            if (_customerRepository.FindCustomer(name) != null)
            {
                throw new ShopsException("Customer is exist!");
            }

            var customer = new Customer(name, balance);

            return _customerRepository.Add(customer);
        }

        public Product AddProduct(Shop shop, string name, int price, int amount)
        {
            if (!_shopRepository.GetAll().Contains(shop))
            {
                throw new ShopsException("This Store is not exist!");
            }

            Product product = _productRepository.FindProduct(shop, name);
            if (product != null)
            {
                product.Amout += amount;
                _productRepository.Update(product);
                return product;
            }

            product = new Product(shop, name, price);
            product.Amout = amount;
            product.Shop = shop;
            _productRepository.Add(product);

            return product;
        }

        public Shop AddShop(string name, string address, int balance)
        {
            var shop = new Shop(name, address, balance);

            return _shopRepository.Add(shop);
        }

        public Bill BuyProduct(Customer customer, Shop shop, string productName, int amount)
        {
            if (!_customerRepository.GetAll().Contains(customer))
            {
                throw new ShopsException("customer is not exist!");
            }

            if (!_shopRepository.GetAll().Contains(shop))
            {
                throw new ShopsException("store is not exist!");
            }

            Product product = _productRepository.FindProduct(shop, productName);
            if (product == null)
            {
                throw new ShopsException("product is not exist in this store!");
            }

            if (product.Amout < amount)
            {
                throw new ShopsException("Amout not enough!");
            }

            int totalMoney = product.Price * amount;

            if (customer.Balance < totalMoney)
            {
                throw new ShopsException("Customer not enough money!");
            }

            customer.Balance -= totalMoney;
            _customerRepository.Update(customer);
            shop.Balance += totalMoney;
            _shopRepository.Update(shop);
            product.Amout -= amount;
            _productRepository.Update(product);

            var bill = new Bill(customer.Id, shop.Id, product.Id, totalMoney, productName, amount);
            return _billRepository.Add(bill);
        }

        public Product ChangeProductPrice(Product product, int newPrice)
        {
            if (!_productRepository.GetAll().Contains(product))
                throw new ShopsException("This product is not exist!");

            product.Price = newPrice;
            _productRepository.Update(product);

            return product;
        }

        public Customer FindCustomer(string name)
        {
            return _customerRepository.FindCustomer(name);
        }

        public Product FindProduct(Shop shop, string name)
        {
            return _productRepository.FindProduct(shop, name);
        }

        public Shop FindShopCheapest(string productName, int amount)
        {
            List<Product> products = _productRepository.FindProducts(productName, amount);
            if (products == null)
            {
                throw new ShopsException("There are no stores with enough amout");
            }

            Product productCheapest = products[0];
            foreach (Product product in products)
            {
                if (product.Price <= productCheapest.Price)
                {
                    productCheapest = product;
                }
            }

            return productCheapest.Shop;
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Shop GetShopById(int id)
        {
            return _shopRepository.GetById(id);
        }

        public Customer RemoveCustomer(int id)
        {
            return _customerRepository.Delete(id);
        }

        public Customer RemoveCustomer(Customer customer)
        {
            return _customerRepository.Delete(customer);
        }

        public Shop RemoveShop(int id)
        {
            return _shopRepository.Delete(id);
        }

        public Shop RemoveShop(Shop shop)
        {
            return _shopRepository.Delete(shop);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public Shop UpdateShop(Shop shop)
        {
            return _shopRepository.Update(shop);
        }
    }
}