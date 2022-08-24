using System.Collections.Generic;
using Backups.Model;

namespace Backups.Archivator
{
    public class SingleStorage : IArchiveAlgorythm
    {
        public List<Storage> Archive(List<JobObject> jobObjects)
        {
            var storages = new List<Storage>();
            var storage = new Storage();
            foreach (JobObject jobObject in jobObjects)
            {
                storage.JobObjects.Add(jobObject);
            }

            storages.Add(storage);

            return storages;
        }
    }
}