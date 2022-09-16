using System.Collections.Generic;
using System.Linq;
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
            var groups = Items.Where(g => g.GroupName.Name == groupName.Name).Select(g => g);

            return groups.Count() == 0 ? null : groups.First();
        }

        public IList<Group> FindGroups(CourseNumber courseNumber)
        {
            var groups = Items.Where(g => g.GroupName.CourseNumber.Course == courseNumber.Course)
                .Select(g => g);

            return groups.Count() == 0 ? null : groups.ToList();
        }
    }
}