using System.Collections.Generic;
using Backups.Model;

namespace Backups.Database
{
    public interface IRepository
    {
        List<Storage> Save(RestorePoint restorePoint);
    }
}