using Isu.Tools;

namespace Isu.Model
{
    public class CourseNumber : IEntity
    {
        private static int cnt = 0;

        public CourseNumber(int course)
        {
            if (course <= 0 || course >= 5)
            {
                throw new IsuException("Error: Invalid Course Number!");
            }

            Id = ++cnt;
            Course = course;
        }

        public int Id { get; set; }

        public int Course { get; set; }
    }
}