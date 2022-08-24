using System;
using System.Collections.Generic;

namespace Backups.Model
{
    public class RestorePoint
    {
        private static int cnt = 0;

        public RestorePoint(List<Storage> storages)
        {
            Id = ++cnt;
            DateCreated = DateTime.Now;
            Storages = storages;
        }

        public int Id { get; private set; }

        public DateTime DateCreated { get; set; }

        public List<Storage> Storages { get; set; }
    }
}