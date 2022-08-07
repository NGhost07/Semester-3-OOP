namespace Shops.Model
{
    public class Bill : IEntity
    {
        private static int _cnt = 0;

        public Bill(int customerId, int storeId, int productID, int totalMoney, string productName, int amout)
        {
            Id = ++_cnt;
            CustomerId = customerId;
            StoreId = storeId;
            ProductId = productID;
            TotalMoney = totalMoney;
            ProductName = productName;
            Amout = amout;
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int StoreId { get; set; }

        public int ProductId { get; set; }

        public int TotalMoney { get; set; }

        public string ProductName { get; set; }

        public int Amout { get; set; }
    }
}