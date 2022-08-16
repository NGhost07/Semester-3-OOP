using Isu.Database.Infrastructure;
using IsuExtra.Database.Infrastructure;
using IsuExtra.Model;

namespace IsuExtra.Database.Repositories
{
    public class TeacherRepository
        : Repository<Teacher>, ITeacherRepository
    {
        private static readonly object _lockObject = new object();
        private static volatile TeacherRepository _teacherRepository;

        public static TeacherRepository GetInstance()
        {
            if (_teacherRepository == null)
            {
                lock (_lockObject)
                {
                    if (_teacherRepository == null)
                    {
                        _teacherRepository = new TeacherRepository();
                    }
                }
            }

            return _teacherRepository;
        }
    }
}