using System.Collections.Generic;
using Backups.Model;

namespace Backups.Archivator
{
    public interface IArchiveAlgorythm
    {
        List<Storage> Archive(List<JobObject> jobObjects);
    }
}