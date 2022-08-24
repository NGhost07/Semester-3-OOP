namespace Backups.Archivator
{
    public enum StorageType
    {
        /// <summary>
        /// Split Storage Algorithm
        /// </summary>
        Split,

        /// <summary>
        /// Single Storage Algorithm
        /// </summary>
        Single,
    }

    public interface IStorageFactory
    {
        IArchiveAlgorythm CreateStorage(StorageType storageType);
    }
}