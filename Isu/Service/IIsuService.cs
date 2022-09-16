using System.Collections.Generic;
using Isu.Model;

namespace Isu.Service
{
    public interface IIsuService
    {
        Group AddGroup(GroupName groupName);
        Student AddStudent(Group group, string name);

        Student GetStudent(int id);
        Student FindStudent(string name);
        IList<Student> FindStudents(GroupName groupName);
        IList<Student> FindStudents(CourseNumber courseNumber);

        Group FindGroup(GroupName groupName);
        IList<Group> FindGroups(CourseNumber courseNumber);

        void ChangeStudentGroup(Student student, Group newGroup);
    }
}