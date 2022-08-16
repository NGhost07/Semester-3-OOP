using System;
using Isu.Model;

namespace IsuExtra.Model
{
    public class Pair : IEntity
    {
        private static int cnt = 0;

        public Pair(int classroom, Teacher teacher, DateTime startTime)
        {
            Id = ++cnt;
            Classroom = classroom;
            Teacher = teacher;
            StartTime = startTime;
        }

        public int Id { get; set; }

        public int Classroom { get; set; }

        public Teacher Teacher { get; set; }

        public DateTime StartTime { get; set; }
    }
}