using Isu.Database.Infrastructure;
using Isu.Database.Repositories;
using Isu.Model;
using Isu.Tools;
using IsuExtra.Database.Infrastructure;
using IsuExtra.Database.Repositories;
using IsuExtra.Model;
using IsuExtra.Services.Infrastructure;

namespace IsuExtra.Services
{
    public class GroupService
        : IGroupService
    {
        private readonly IGroupNameRepository _groupNameRepository;
        private readonly IGroupExtraRepository _groupExtraRepository;

        public GroupService()
        {
            _groupNameRepository = GroupNameRepository.GetInstance();
            _groupExtraRepository = GroupExtraRepository.GetInstance();
        }

        public GroupExtra AddGroup(GroupName groupName)
        {
            if (_groupNameRepository.FindGroupName(groupName.Name) != null)
            {
                throw new IsuException("This Group existed!");
            }

            _groupNameRepository.Add(groupName);

            var group = new GroupExtra(groupName);

            return _groupExtraRepository.Add(group);
        }

        public GroupExtra GetGroup(int id)
        {
            return _groupExtraRepository.GetById(id);
        }

        public GroupExtra RemoveGroup(GroupExtra group)
        {
            return _groupExtraRepository.Delete(group);
        }

        public GroupExtra RemoveGroup(int id)
        {
            return _groupExtraRepository.Delete(id);
        }

        public GroupExtra UpdateGroup(GroupExtra groupExtra)
        {
            return _groupExtraRepository.Update(groupExtra);
        }
    }
}