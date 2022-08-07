using System.Collections.Generic;
using Isu.Model;

namespace Isu.Database.Infrastructure
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student FindStudent(string name);
        List<Student> FindStudents(GroupName groupName);
        List<Student> FindStudents(CourseNumber courseNumber);
    }
}