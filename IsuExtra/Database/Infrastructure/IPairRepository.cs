using System.Collections.Generic;
using Isu.Database.Infrastructure;
using IsuExtra.Model;

namespace IsuExtra.Database.Infrastructure
{
    public interface IPairRepository
        : IRepository<Pair>
    {
        List<Pair> GetPairs(GroupExtra groupExtra);
    }
}