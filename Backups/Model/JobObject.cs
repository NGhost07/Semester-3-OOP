using System.IO;

namespace Backups.Model
{
    public class JobObject
    {
        public JobObject(FileInfo fileInfo)
        {
            FileInfor = fileInfo;
        }

        public FileInfo FileInfor { get; set; }
    }
}