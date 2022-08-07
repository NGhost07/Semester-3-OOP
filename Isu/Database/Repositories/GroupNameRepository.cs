using Isu.Database.Infrastructure;
using Isu.Model;

namespace Isu.Database.Repositories
{
    public class GroupNameRepository
        : Repository<GroupName>, IGroupNameRepository
    {
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