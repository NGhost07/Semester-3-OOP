using System.Collections.Generic;
using Isu.Database.Infrastructure;
using IsuExtra.Model;

namespace IsuExtra.Database.Infrastructure
{
    public interface IStudentExtraRepository
        : IRepository<StudentExtra>
    {
        List<StudentExtra> FindStudents(GroupExtra group);
    }
}