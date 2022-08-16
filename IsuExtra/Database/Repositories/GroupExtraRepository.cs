using Isu.Database.Infrastructure;
using IsuExtra.Database.Infrastructure;
using IsuExtra.Model;

namespace IsuExtra.Database.Repositories
{
    public class GroupExtraRepository
        : Repository<GroupExtra>, IGroupExtraRepository
    {
        private static readonly object _lockObject = new object();
        private static volatile GroupExtraRepository _groupExtraRepository;

        public static GroupExtraRepository GetInstance()
        {
            if (_groupExtraRepository == null)
            {
                lock (_lockObject)
                {
                    if (_groupExtraRepository == null)
                    {
                        _groupExtraRepository = new GroupExtraRepository();
                    }
                }
            }

            return _groupExtraRepository;
        }
    }
}