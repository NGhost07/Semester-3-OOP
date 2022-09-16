namespace Isu.Model
{
    public class Student : IEntity
    {
        private static int cnt = 0;

        public Student(Group group, string name)
        {
            Id = ++cnt;
            Name = name;
            Group = group;
        }

        public int Id { get; private set; }

        public string Name { get; set; }

        public Group Group { get; set; }
    }
}