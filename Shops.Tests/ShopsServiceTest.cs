using NUnit.Framework;
using Shops.Service;

namespace Shops.Tests
{
    [TestFixture]
    public class ShopsServiceTest
    {
        private IShopsService _shopsService;

        [SetUp]
        public void SetUp()
        {
            _shopsService = new ShopsService();
        }

        [Test]
        public void Addshop()
        {
            var shop = _shopsService.AddShop("Shop 1", "Address 1", 100);

            Assert.IsNotNull(shop);
            Assert.AreEqual(shop.Id, 1);
            Assert.AreEqual(shop.Address, "Address 1");
            Assert.AreEqual(shop.Name, "Shop 1");
            Assert.AreEqual(shop.Balance, 100);
        }

        [Test]
        public void GetshopById()
        {
            _shopsService.AddShop("Shop 1", "Address 1", 100);
            var shop = _shopsService.GetShopById(1);

            Assert.IsNotNull(shop);
            Assert.AreEqual(shop.Id, 1);
            Assert.AreEqual(shop.Address, "Address 1");
        }

        [Test]
        public void ChangeProductPrice()
        {
            var shop = _shopsService.AddShop("Shop 1", "Address 1", 100);
            _shopsService.AddProduct(shop, "Product 1", 10, 2);
            var product = _shopsService.GetProductById(1);
            _shopsService.ChangeProductPrice(product, 11);

            Assert.IsNotNull(product);
            Assert.AreEqual(product.Price, 11);
        }

        [Test]
        public void FindshopCheapest()
        {
            var shop1 = _shopsService.AddShop("shop 1", "address 1", 1000);
            var shop2 = _shopsService.AddShop("shop 2", "address 2", 1000);
            _shopsService.AddProduct(shop1, "product 1", 100, 50);
            _shopsService.AddProduct(shop2, "product 1", 90, 50);
            var shop = _shopsService.FindShopCheapest("product 1", 1);

            Assert.IsNotNull(shop);
            Assert.AreEqual(shop.Id, 2);
            Assert.AreEqual(shop.Name, "shop 2");
        }

        [Test]
        public void BuyProduct()
        {
            var store1 = _shopsService.AddShop("store 1", "address 1", 1000);
            var product = _shopsService.AddProduct(store1, "product 1", 50, 10);
            var customer = _shopsService.AddCustomer("customer 1", 200);
            var bill = _shopsService.BuyProduct(customer, store1, "product 1", 2);

            Assert.IsNotNull(bill);
            Assert.AreEqual(store1.Balance, 1100);
            Assert.AreEqual(customer.Balance, 100);
            Assert.AreEqual(product.Amout, 8);
            Assert.AreEqual(bill.Id, 1);
            Assert.AreEqual(bill.ProductName, "product 1");
            Assert.AreEqual(bill.Amout, 2);
            Assert.AreEqual(bill.TotalMoney, 100);
        }
    }
}

