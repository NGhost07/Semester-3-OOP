using System.Collections.Generic;
using Isu.Database.Infrastructure;
using IsuExtra.Model;

namespace IsuExtra.Database.Infrastructure
{
    public interface IStudyStreamRepository
        : IRepository<StudyStream>
    {
        List<StudyStream> GetStudyStreams(OGNP ognp);
    }
}