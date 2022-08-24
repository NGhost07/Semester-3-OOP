using System.Collections.Generic;
using Backups.Archivator;
using Backups.Database;
using Backups.Model;

namespace Backups.Service
{
    public interface IBackupsService
    {
        string Name { get; set; }

        IArchiveAlgorythm ArchiveAlgorythm { get; }

        IRepository Repository { get; }

        List<JobObject> JobObjects { get; }

        List<RestorePoint> RestorePoints { get; }

        JobObject AddJobObject(JobObject jobObject);

        JobObject RemoveJobObject(JobObject jobObject);

        void Backup();
    }
}