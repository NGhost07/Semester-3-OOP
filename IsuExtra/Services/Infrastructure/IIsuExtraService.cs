using System.Collections.Generic;
using IsuExtra.Model;

namespace IsuExtra.Services.Infrastructure
{
    public interface IIsuExtraService
    {
        OGNP AddOGNP(OGNP ognp);
        OGNP GetOGNP(int id);
        OGNP UpdateOGNP(OGNP ognp);
        OGNP RemoveOGNP(OGNP ognp);
        OGNP RemoveOGNP(int id);

        StudyStream AddStudyStream(StudyStream studyStream);
        StudyStream GetStudyStream(int id);
        StudyStream UpdateStudyStream(StudyStream studyStream);
        StudyStream RemoveStudyStream(StudyStream studyStream);
        StudyStream RemoveStudyStream(int id);

        void RegisterOGNP(StudentExtra student, StudyStream studyStream);
        void UnRegisterOGNP(StudentExtra student, OGNP ognp);
        List<StudyStream> GetStudyStreams(OGNP ognp);
        List<StudentExtra> GetStudentsRegistered(OGNP ognp);
        List<StudentExtra> GetStudentsUnRegistered(GroupExtra group);
    }
}