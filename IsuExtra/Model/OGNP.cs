using Isu.Model;

namespace IsuExtra.Model
{
    public class OGNP : IEntity
    {
        private static int cnt = 0;

        public OGNP(string name, char megafaculty)
        {
            Id = ++cnt;
            Name = name;
            Megafaculty = megafaculty;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public char Megafaculty { get; set; }
    }
}