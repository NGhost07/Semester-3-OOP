using System.Collections.Generic;
using Isu.Database.Infrastructure;
using Isu.Database.Repositories;
using Isu.Model;
using Isu.Tools;

namespace Isu.Service
{
    public class IsuService : IIsuService
    {
        private ICourseNumberRepository _courseNumberRepository;
        private IGroupNameRepository _groupNameRepository;
        private IGroupRepository _groupRepository;
        private IStudentRepository _studentRepository;

        public IsuService()
        {
            _courseNumberRepository = CourseNumberRepository.GetInstance();
            _groupNameRepository = GroupNameRepository.GetInstance();
            _groupRepository = GroupRepository.GetInstance();
            _studentRepository = StudentRepository.GetInstance();
        }

        public Group AddGroup(GroupName groupName)
        {
            if (_groupNameRepository.FindGroupName(groupName.Name) != null)
            {
                throw new IsuException("This Group existed!");
            }

            var group = new Group(groupName);
            _groupNameRepository.Add(groupName);

            return _groupRepository.Add(group);
        }

        public Student AddStudent(Group group, string name)
        {
            if (!_groupRepository.GetAll().Contains(group))
            {
                throw new IsuException("This group is not exist!");
            }

            var student = new Student(group, name);

            return _studentRepository.Add(student);
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            if (!_groupRepository.GetAll().Contains(newGroup))
            {
                throw new IsuException("New group is not exist!");
            }

            student.Group = newGroup;

            _studentRepository.Update(student);
        }

        public Group FindGroup(GroupName groupName)
        {
            return _groupRepository.FindGroup(groupName);
        }

        public IList<Group> FindGroups(CourseNumber courseNumber)
        {
            return _groupRepository.FindGroups(courseNumber);
        }

        public Student FindStudent(string name)
        {
            return _studentRepository.FindStudent(name);
        }

        public IList<Student> FindStudents(GroupName groupName)
        {
            return _studentRepository.FindStudents(groupName);
        }

        public IList<Student> FindStudents(CourseNumber courseNumber)
        {
            return _studentRepository.FindStudents(courseNumber);
        }

        public Student GetStudent(int id)
        {
            Student student = _studentRepository.GetById(id);

            return student == null ? throw new IsuException("This student is not exist!") : student;
        }
    }
}