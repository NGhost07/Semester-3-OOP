using Backups.Common;

namespace Backups.Archivator
{
    public class StorageFactory : IStorageFactory
    {
        public IArchiveAlgorythm CreateStorage(StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Split:
                    return new SplitStorage();

                case StorageType.Single:
                    return new SingleStorage();
            }

            throw new BackupsException("Can not create storage!");
        }
    }
}