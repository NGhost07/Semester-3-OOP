using System.Collections.Generic;
using Isu.Model;

namespace IsuExtra.Model
{
    public class StudyStream : IEntity
    {
        private static int cnt = 0;

        public StudyStream(OGNP ognp, int limitStudents)
        {
            Id = ++cnt;
            LimitStudents = limitStudents;
            OGNP = ognp;
            Students = new List<StudentExtra>();
            Pairs = new List<Pair>();
        }

        public int Id { get; set; }

        public int LimitStudents { get; set; }

        public OGNP OGNP { get; set; }

        public List<StudentExtra> Students { get; set; }

        public List<Pair> Pairs { get; set; }
    }
}