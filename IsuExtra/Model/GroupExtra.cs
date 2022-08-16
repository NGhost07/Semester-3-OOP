using System.Collections.Generic;
using Isu.Model;

namespace IsuExtra.Model
{
    public class GroupExtra : Group
    {
        private static int _cnt = 0;

        public GroupExtra(GroupName groupName)
            : base(groupName)
        {
            Id = ++_cnt;
            Megafaculty = groupName.Name[0];
            Pairs = new List<Pair>();
        }

        public char Megafaculty { get; set; }

        public List<Pair> Pairs { get; set; }
    }
}