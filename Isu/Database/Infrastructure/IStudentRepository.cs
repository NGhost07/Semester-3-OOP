using System.Collections.Generic;
using Isu.Model;

namespace Isu.Database.Infrastructure
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student FindStudent(string name);
        IList<Student> FindStudents(GroupName groupName);
        IList<Student> FindStudents(CourseNumber courseNumber);
    }
}