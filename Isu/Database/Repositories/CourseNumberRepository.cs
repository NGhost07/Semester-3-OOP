using Isu.Database.Infrastructure;
using Isu.Model;

namespace Isu.Database.Repositories
{
    public class CourseNumberRepository
        : Repository<CourseNumber>, ICourseNumberRepository
    {
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
