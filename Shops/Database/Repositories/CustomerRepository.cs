using Shops.Database.Infrastructure;
using Shops.Model;

namespace Shops.Database.Repositories
{
    public class CustomerRepository
        : Repository<Customer>, ICustomerRepository
    {
        public Customer FindCustomer(string name)
        {
            foreach (Customer customer in Items)
            {
                if (customer.Name == name)
                {
                    return customer;
                }
            }

            return null;
        }
    }
}