using System.Linq;
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
            var courses = Items.Where(c => c.Course == course).Select(c => c);

            return courses.Count() == 0 ? null : courses.First();
        }
    }
}
