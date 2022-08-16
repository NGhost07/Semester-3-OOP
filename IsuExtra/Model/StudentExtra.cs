using System.Collections.Generic;
using Isu.Model;

namespace IsuExtra.Model
{
    public class StudentExtra : Student
    {
        private static int _cnt = 0;

        public StudentExtra(GroupExtra group, string name)
            : base(group, name)
        {
            Id = ++_cnt;
            Megafaculty = group.Megafaculty;
            GroupExtra = group;
            Pairs = new List<Pair>();
        }

        public char Megafaculty { get; set; }

        public GroupExtra GroupExtra { get; set; }

        public List<Pair> Pairs { get; set; }
    }
}