using System.Collections.Generic;
using Isu.Database.Infrastructure;
using IsuExtra.Database.Infrastructure;
using IsuExtra.Model;

namespace IsuExtra.Database.Repositories
{
    public class PairRepository
        : Repository<Pair>, IPairRepository
    {
        private static readonly object _lockObject = new object();
        private static volatile PairRepository _pairRepository;

        public static PairRepository GetInstance()
        {
            if (_pairRepository == null)
            {
                lock (_lockObject)
                {
                    if (_pairRepository == null)
                    {
                        _pairRepository = new PairRepository();
                    }
                }
            }

            return _pairRepository;
        }

        public List<Pair> GetPairs(GroupExtra groupExtra)
        {
            return groupExtra.Pairs;
        }
    }
}