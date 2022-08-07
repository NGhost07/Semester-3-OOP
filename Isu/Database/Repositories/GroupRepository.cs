using System.Collections.Generic;
using Isu.Database.Infrastructure;
using Isu.Model;

namespace Isu.Database.Repositories
{
    public class GroupRepository
        : Repository<Group>, IGroupRepository
    {
        public GroupRepository()
        {
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