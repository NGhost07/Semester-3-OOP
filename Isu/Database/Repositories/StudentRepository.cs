using System.Collections.Generic;
using System.Linq;
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
            var students = Items.Where(student => student.Name == name).Select(student => student);

            return students.First();
        }

        public IList<Student> FindStudents(GroupName groupName)
        {
            var students = Items.Where(s => s.Group.GroupName.Name == groupName.Name)
                .Select(s => s);

            return students.Count() == 0 ? null : students.ToList();
        }

        public IList<Student> FindStudents(CourseNumber courseNumber)
        {
            var students = Items.Where(s => s.Group.GroupName.CourseNumber.Course == courseNumber.Course)
                .Select(s => s);

            return students.Count() == 0 ? null : students.ToList();
        }
    }
}