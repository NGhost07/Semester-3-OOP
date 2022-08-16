using Isu.Model;

namespace IsuExtra.Model
{
    public class Teacher : IEntity
    {
        private static int cnt = 0;

        public Teacher(string name)
        {
            Id = ++cnt;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}