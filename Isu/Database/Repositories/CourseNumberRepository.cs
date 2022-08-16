using Isu.Database.Infrastructure;
using Isu.Model;

namespace Isu.Database.Repositories
{
    public class CourseNumberRepository
        : Repository<CourseNumber>, ICourseNumberRepository
    {
        private static readonly object _lockObject = new object();
        private static volatile CourseNumberRepository _courseNumberRepository;

        public static CourseNumberRepository GetInstance()
        {
            if (_courseNumberRepository == null)
            {
                lock (_lockObject)
                {
                    if (_courseNumberRepository == null)
                    {
                        _courseNumberRepository = new CourseNumberRepository();
                    }
                }
            }

            return _courseNumberRepository;
        }

        public CourseNumber FindCourseNumber(int course)
        {
            foreach (CourseNumber courseNumber in Items)
            {
                if (courseNumber.Course == course)
                {
                    return courseNumber;
                }
            }

            return null;
        }
    }
}
