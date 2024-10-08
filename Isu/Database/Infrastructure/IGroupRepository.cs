﻿using System.Collections.Generic;
using Isu.Model;

namespace Isu.Database.Infrastructure
{
    public interface IGroupRepository : IRepository<Group>
    {
        Group FindGroup(GroupName groupName);
        IList<Group> FindGroups(CourseNumber courseNumber);
    }
}