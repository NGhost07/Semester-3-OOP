using Shops.Database.Infrastructure;
using Shops.Model;

namespace Shops.Database.Repositories
{
    public class ShopRepository
        : Repository<Shop>, IShopRepository
    {
    }
}