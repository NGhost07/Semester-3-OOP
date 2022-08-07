using Isu.Tools;

namespace Isu.Model
{
    public class GroupName : IEntity
    {
        private static int cnt = 0;

        public GroupName(string groupName)
        {
            if (groupName.Substring(0, 2) != "M3"
                || int.Parse(groupName.Substring(2, 3)) < 100
                || int.Parse(groupName.Substring(2, 3)) > 999)
            {
                throw new IsuException("Error: Invalid Group Name!");
            }

            Id = ++cnt;
            Name = groupName;
            CourseNumber = new CourseNumber(int.Parse(groupName.Substring(2, 1)));
            GroupNumber = int.Parse(groupName.Substring(3, 2));
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public CourseNumber CourseNumber { get; set; }

        public int GroupNumber { get; set; }
    }
}