namespace Shops.Model
{
    public class Customer : IEntity
    {
        private static int _cnt = 0;

        public Customer(string name, int balance)
        {
            Id = ++_cnt;
            Name = name;
            Balance = balance;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Balance { get; set; }
    }
}