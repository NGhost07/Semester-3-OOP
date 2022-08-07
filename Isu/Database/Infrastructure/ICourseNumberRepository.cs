using Isu.Model;

namespace Isu.Database.Infrastructure
{
    public interface ICourseNumberRepository : IRepository<CourseNumber>
    {
        CourseNumber FindCourseNumber(int course);
    }
}