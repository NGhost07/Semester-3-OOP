using Shops.Model;

namespace Shops.Database.Infrastructure
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer FindCustomer(string name);
    }
}