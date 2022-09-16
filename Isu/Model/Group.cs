namespace Isu.Model
{
    public class Group : IEntity
    {
        private static int cnt = 0;

        public Group(GroupName groupName)
        {
            Id = ++cnt;
            GroupName = groupName;
        }

        public int Id { get; private set; }

        public GroupName GroupName { get; private set; }
    }
}