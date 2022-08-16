using System.Collections.Generic;
using Isu.Database.Infrastructure;
using IsuExtra.Database.Infrastructure;
using IsuExtra.Model;

namespace IsuExtra.Database.Repositories
{
    public class StudyStreamRepository
        : Repository<StudyStream>, IStudyStreamRepository
    {
        private static readonly object _lockObject = new object();
        private static volatile StudyStreamRepository _studyStreamRepository;

        public static StudyStreamRepository GetInstance()
        {
            if (_studyStreamRepository == null)
            {
                lock (_lockObject)
                {
                    if (_studyStreamRepository == null)
                    {
                        _studyStreamRepository = new StudyStreamRepository();
                    }
                }
            }

            return _studyStreamRepository;
        }

        public List<StudyStream> GetStudyStreams(OGNP ognp)
        {
            var studyStreams = new List<StudyStream>();
            foreach (StudyStream studyStream in Items)
            {
                if (studyStream.OGNP == ognp)
                {
                    studyStreams.Add(studyStream);
                }
            }

            return studyStreams;
        }
    }
}