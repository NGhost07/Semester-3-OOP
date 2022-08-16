using Isu.Database.Infrastructure;
using IsuExtra.Database.Infrastructure;
using IsuExtra.Model;

namespace IsuExtra.Database.Repositories
{
    public class OGNPRepository
        : Repository<OGNP>, IOGNPRepository
    {
        private static readonly object _lockObject = new object();
        private static volatile OGNPRepository _oGNPRepository;

        public static OGNPRepository GetInstance()
        {
            if (_oGNPRepository == null)
            {
                lock (_lockObject)
                {
                    if (_oGNPRepository == null)
                    {
                        _oGNPRepository = new OGNPRepository();
                    }
                }
            }

            return _oGNPRepository;
        }

        public OGNP FindOGNP(string name)
        {
            foreach (OGNP oGNP in Items)
            {
                if (oGNP.Name == name)
                {
                    return oGNP;
                }
            }

            return null;
        }
    }
}