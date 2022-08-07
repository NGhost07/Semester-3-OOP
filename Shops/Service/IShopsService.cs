using Shops.Model;

namespace Shops.Service
{
    public interface IShopsService
    {
        Customer AddCustomer(string name, int balance);
        Customer GetCustomerById(int id);
        Customer UpdateCustomer(Customer customer);
        Customer RemoveCustomer(int id);
        Customer RemoveCustomer(Customer customer);
        Customer FindCustomer(string name);

        Shop AddShop(string name, string address, int balance);
        Shop GetShopById(int id);
        Shop UpdateShop(Shop shop);
        Shop RemoveShop(int id);
        Shop RemoveShop(Shop shop);

        Product AddProduct(Shop shop, string name, int price, int amount);
        Product GetProductById(int id);
        Product FindProduct(Shop shop, string name);
        Product ChangeProductPrice(Product product, int newPrice);

        Bill BuyProduct(Customer customer, Shop shop, string productName, int amount);
        Shop FindShopCheapest(string productName, int amount);
    }
}