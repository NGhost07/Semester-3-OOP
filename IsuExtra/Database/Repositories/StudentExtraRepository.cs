using System.Collections.Generic;
using Isu.Database.Infrastructure;
using IsuExtra.Database.Infrastructure;
using IsuExtra.Model;

namespace IsuExtra.Database.Repositories
{
    public class StudentExtraRepository
        : Repository<StudentExtra>, IStudentExtraRepository
    {
        private static readonly object _lockObject = new object();
        private static volatile StudentExtraRepository _studentExtraRepository;

        public static StudentExtraRepository GetInstance()
        {
            if (_studentExtraRepository == null)
            {
                lock (_lockObject)
                {
                    if (_studentExtraRepository == null)
                    {
                        _studentExtraRepository = new StudentExtraRepository();
                    }
                }
            }

            return _studentExtraRepository;
        }

        public List<StudentExtra> FindStudents(GroupExtra group)
        {
            var students = new List<StudentExtra>();
            foreach (StudentExtra student in Items)
            {
                if (student.Group == group)
                {
                    students.Add(student);
                }
            }

            return students;
        }
    }
}