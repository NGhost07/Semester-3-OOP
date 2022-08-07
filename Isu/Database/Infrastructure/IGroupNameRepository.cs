using Isu.Model;

namespace Isu.Database.Infrastructure
{
    public interface IGroupNameRepository : IRepository<GroupName>
    {
        GroupName FindGroupName(string groupName);
    }
}