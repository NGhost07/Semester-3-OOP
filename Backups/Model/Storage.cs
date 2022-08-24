using System.Collections.Generic;

namespace Backups.Model
{
    public class Storage
    {
        private static int _cnt = 0;

        public Storage()
        {
            Id = ++_cnt;
            JobObjects = new List<JobObject>();
        }

        public int Id { get; private set; }

        public List<JobObject> JobObjects { get; set; }
    }
}