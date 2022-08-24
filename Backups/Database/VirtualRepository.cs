using System.Collections.Generic;
using Backups.Model;

namespace Backups.Database
{
    public class VirtualRepository : IRepository
    {
        public VirtualRepository()
        {
        }

        public List<Storage> Save(RestorePoint restorePoint)
        {
            return restorePoint.Storages;
        }
    }
}