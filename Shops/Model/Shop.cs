namespace Shops.Model
{
    public class Shop : IEntity
    {
        private static int _cnt = 0;

        public Shop(string name, string address, int balance)
        {
            Id = ++_cnt;
            Name = name;
            Address = address;
            Balance = balance;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int Balance { get; set; }
    }
}