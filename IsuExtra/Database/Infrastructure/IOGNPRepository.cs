using Isu.Database.Infrastructure;
using IsuExtra.Model;

namespace IsuExtra.Database.Infrastructure
{
    public interface IOGNPRepository
        : IRepository<OGNP>
    {
        OGNP FindOGNP(string name);
    }
}