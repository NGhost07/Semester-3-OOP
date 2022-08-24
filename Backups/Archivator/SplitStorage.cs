using System.Collections.Generic;
using Backups.Model;

namespace Backups.Archivator
{
    public class SplitStorage : IArchiveAlgorythm
    {
        public List<Storage> Archive(List<JobObject> jobObjects)
        {
            var storages = new List<Storage>();
            foreach (JobObject jobObject in jobObjects)
            {
                var storage = new Storage();
                storage.JobObjects.Add(jobObject);
                storages.Add(storage);
            }

            return storages;
        }
    }
}