using Isu.Model;
using IsuExtra.Model;

namespace IsuExtra.Services.Infrastructure
{
    public interface IGroupService
    {
        GroupExtra AddGroup(GroupName groupName);
        GroupExtra GetGroup(int id);
        GroupExtra RemoveGroup(GroupExtra group);
        GroupExtra RemoveGroup(int id);
        GroupExtra UpdateGroup(GroupExtra groupExtra);
    }
}