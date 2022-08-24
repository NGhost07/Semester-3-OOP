using System.IO;
using Backups.Archivator;
using Backups.Database;
using Backups.Model;
using Backups.Service;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var jobObject1 = new JobObject(new FileInfo("/Users/tranhoangnam/Desktop/BackupFile/file1"));
            var jobObject2 = new JobObject(new FileInfo("/Users/tranhoangnam/Desktop/BackupFile/file2"));
            var jobObject3 = new JobObject(new FileInfo("/Users/tranhoangnam/Desktop/BackupFile/file3"));

            IArchiveAlgorythm archiveAlgorythm = new StorageFactory().CreateStorage(StorageType.Single);
            IRepository repository = new LocalRepository(new DirectoryInfo("/Users/tranhoangnam/Desktop/BackupFile"));

            IBackupsService backupsService = new BackupsService("Backup", archiveAlgorythm, repository);

            backupsService.AddJobObject(jobObject1);
            backupsService.AddJobObject(jobObject2);
            backupsService.AddJobObject(jobObject3);

            backupsService.Backup();

            backupsService.RemoveJobObject(jobObject1);

            backupsService.Backup();
        }
    }
}
