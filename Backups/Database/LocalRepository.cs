using System.Collections.Generic;
using System.IO;
using Backups.Model;
using Ionic.Zip;

namespace Backups.Database
{
    public class LocalRepository : IRepository
    {
        public LocalRepository(DirectoryInfo path)
        {
            Path = path;
        }

        public DirectoryInfo Path { get; set; }

        public List<Storage> Save(RestorePoint restorePoint)
        {
            foreach (Storage storage in restorePoint.Storages)
            {
                var zipFile = new ZipFile();
                foreach (JobObject jobObject in storage.JobObjects)
                {
                    zipFile.AddFile(jobObject.FileInfor.FullName);
                }

                zipFile.Save(Path.FullName + "/" + restorePoint.Id + "_" + storage.Id + ".zip");
            }

            return restorePoint.Storages;
        }
    }
}