using System.Collections.Generic;
using Isu.Database.Infrastructure;
using Isu.Model;

namespace Isu.Database.Repositories
{
    public class GroupRepository
        : Repository<Group>, IGroupRepository
    {
        private static readonly object _lockObject = new object();
        private static volatile GroupRepository _groupRepository;

        public static GroupRepository GetInstance()
        {
            if (_groupRepository == null)
            {
                lock (_lockObject)
                {
                    if (_groupRepository == null)
                    {
                        _groupRepository = new GroupRepository();
                    }
                }
            }

            return _groupRepository;
        }

        public Group FindGroup(GroupName groupName)
        {
            foreach (Group group in Items)
            {
                if (group.GroupName.Name == groupName.Name)
                {
                    return group;
                }
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var groups = new List<Group>();
            foreach (Group group in Items)
            {
                if (group.GroupName.CourseNumber.Course == courseNumber.Course)
                {
                    groups.Add(group);
                }
            }

            return groups;
        }
    }
}