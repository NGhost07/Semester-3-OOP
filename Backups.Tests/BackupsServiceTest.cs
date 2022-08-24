using System.IO;
using Backups.Archivator;
using Backups.Database;
using Backups.Model;
using Backups.Service;
using NUnit.Framework;

namespace Backups.Tests
{
    [TestFixture]
    public class BackupsServiceTest
    {
        private IBackupsService _backupsService;

        private JobObject _jobObject1;
        private JobObject _jobObject2;
        private JobObject _jobObject3;

        [SetUp]
        public void Setup()
        {
            _jobObject1 = new JobObject(new FileInfo($"/BackupFile/file1"));
            _jobObject2 = new JobObject(new FileInfo($"/BackupFile/file2"));
            _jobObject3 = new JobObject(new FileInfo($"/BackupFile/file3"));

            IArchiveAlgorythm archiveAlgorythm = new StorageFactory().CreateStorage(StorageType.Split);
            IRepository repository = new VirtualRepository();

            _backupsService = new BackupsService("Backup", archiveAlgorythm, repository);
        }

        [Test]
        public void Test1()
        {
            _backupsService.AddJobObject(_jobObject1);
            _backupsService.AddJobObject(_jobObject2);
            _backupsService.AddJobObject(_jobObject3);

            _backupsService.Backup();

            _backupsService.RemoveJobObject(_jobObject3);

            _backupsService.Backup();

            Assert.AreEqual(_backupsService.Name, "Backup");
            Assert.AreEqual(_backupsService.RestorePoints.Count, 2);
            Assert.AreEqual(_backupsService.RestorePoints[0].Storages.Count, 3);
            Assert.AreEqual(_backupsService.RestorePoints[1].Storages.Count, 2);
        }
    }
}

