using System.Collections.Generic;
using Backups.Archivator;
using Backups.Database;
using Backups.Model;

namespace Backups.Service
{
    public class BackupsService : IBackupsService
    {
        public BackupsService(string name, IArchiveAlgorythm archiveAlgorythm, IRepository repository)
        {
            Name = name;
            ArchiveAlgorythm = archiveAlgorythm;
            Repository = repository;
            JobObjects = new List<JobObject>();
            RestorePoints = new List<RestorePoint>();
        }

        public string Name { get; set; }

        public IArchiveAlgorythm ArchiveAlgorythm { get; private set; }

        public IRepository Repository { get; private set; }

        public List<JobObject> JobObjects { get; private set; }

        public List<RestorePoint> RestorePoints { get; private set; }

        public JobObject AddJobObject(JobObject jobObject)
        {
            JobObjects.Add(jobObject);

            return jobObject;
        }

        public JobObject RemoveJobObject(JobObject jobObject)
        {
            JobObjects.Remove(jobObject);

            return jobObject;
        }

        public void Backup()
        {
            var restorePoint = new RestorePoint(ArchiveAlgorythm.Archive(JobObjects));

            RestorePoints.Add(restorePoint);

            Repository.Save(restorePoint);
        }
    }
}