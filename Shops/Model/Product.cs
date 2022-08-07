namespace Shops.Model
{
    public class Product : IEntity
    {
        private static int _cnt = 0;

        public Product(Shop shop, string name, int price)
        {
            Id = ++_cnt;
            Name = name;
            Price = price;
            Shop = shop;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Amout { get; set; }

        public Shop Shop { get; set; }
    }
}