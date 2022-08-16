using Isu.Database.Infrastructure;
using Isu.Model;

namespace Isu.Database.Repositories
{
    public class GroupNameRepository
        : Repository<GroupName>, IGroupNameRepository
    {
        private static readonly object _lockObject = new object();
        private static volatile GroupNameRepository _groupNameRepository;

        public static GroupNameRepository GetInstance()
        {
            if (_groupNameRepository == null)
            {
                lock (_lockObject)
                {
                    if (_groupNameRepository == null)
                    {
                        _groupNameRepository = new GroupNameRepository();
                    }
                }
            }

            return _groupNameRepository;
        }

        public GroupName FindGroupName(string name)
        {
            foreach (GroupName groupName in Items)
            {
                if (groupName.Name == name)
                {
                    return groupName;
                }
            }

            return null;
        }
    }
}