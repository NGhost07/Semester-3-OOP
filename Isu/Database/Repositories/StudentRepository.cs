using System.Collections.Generic;
using Isu.Database.Infrastructure;
using Isu.Model;

namespace Isu.Database.Repositories
{
    public class StudentRepository
        : Repository<Student>, IStudentRepository
    {
        private static readonly object _lockObject = new object();
        private static volatile StudentRepository _studentRepository;

        public static StudentRepository GetInstance()
        {
            if (_studentRepository == null)
            {
                lock (_lockObject)
                {
                    if (_studentRepository == null)
                    {
                        _studentRepository = new StudentRepository();
                    }
                }
            }

            return _studentRepository;
        }

        public Student FindStudent(string name)
        {
            foreach (Student student in Items)
            {
                if (student.Name == name)
                {
                    return student;
                }
            }

            return null;
        }

        public List<Student> FindStudents(GroupName groupName)
        {
            var students = new List<Student>();
            foreach (Student student in Items)
            {
                if (student.Group.GroupName.Name == groupName.Name)
                {
                    students.Add(student);
                }
            }

            return students;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var students = new List<Student>();
            foreach (Student student in Items)
            {
                if (student.Group.GroupName.CourseNumber.Course == courseNumber.Course)
                {
                    students.Add(student);
                }
            }

            return students;
        }
    }
}