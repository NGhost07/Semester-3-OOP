using Isu.Tools;

namespace Isu.Model
{
    public class GroupName : IEntity
    {
        private static int cnt = 0;

        public GroupName(string groupName)
        {
            char c = groupName.Substring(0, 1).ToCharArray()[0];
            if (!char.IsUpper(c)
                || int.Parse(groupName.Substring(1, 4)) < 1000
                || int.Parse(groupName.Substring(1, 4)) > 9999)
            {
                throw new IsuException("Error: Invalid Group Name!");
            }

            Id = ++cnt;
            Name = groupName;
            CourseNumber = new CourseNumber(int.Parse(groupName.Substring(2, 1)));
            GroupNumber = int.Parse(groupName.Substring(3, 2));
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public CourseNumber CourseNumber { get; private set; }

        public int GroupNumber { get; private set; }
    }
}