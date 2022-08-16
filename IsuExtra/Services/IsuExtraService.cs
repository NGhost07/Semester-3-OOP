using System.Collections.Generic;
using Isu.Tools;
using IsuExtra.Database.Infrastructure;
using IsuExtra.Database.Repositories;
using IsuExtra.Model;
using IsuExtra.Services.Infrastructure;

namespace IsuExtra.Services
{
    public class IsuExtraService
        : IIsuExtraService
    {
        private readonly IOGNPRepository _oGNPRepository;
        private readonly IStudentExtraRepository _studentRepository;
        private readonly IStudyStreamRepository _studyStreamRepository;
        private readonly IPairRepository _pairRepository;
        private readonly ITeacherRepository _teacherRepository;

        public IsuExtraService()
        {
            _oGNPRepository = OGNPRepository.GetInstance();
            _studentRepository = StudentExtraRepository.GetInstance();
            _studyStreamRepository = StudyStreamRepository.GetInstance();
            _pairRepository = PairRepository.GetInstance();
            _teacherRepository = TeacherRepository.GetInstance();
        }

        public OGNP AddOGNP(OGNP ognp)
        {
            if (_oGNPRepository.FindOGNP(ognp.Name) != null)
                throw new IsuException("This OGNP is exist!");

            return _oGNPRepository.Add(ognp);
        }

        public OGNP GetOGNP(int id)
        {
            return _oGNPRepository.GetById(id);
        }

        public OGNP UpdateOGNP(OGNP ognp)
        {
            return _oGNPRepository.Update(ognp);
        }

        public OGNP RemoveOGNP(OGNP ognp)
        {
            return _oGNPRepository.Delete(ognp);
        }

        public OGNP RemoveOGNP(int id)
        {
            return _oGNPRepository.Delete(id);
        }

        public StudyStream AddStudyStream(StudyStream studyStream)
        {
            return _studyStreamRepository.Add(studyStream);
        }

        public StudyStream GetStudyStream(int id)
        {
            return _studyStreamRepository.GetById(id);
        }

        public StudyStream UpdateStudyStream(StudyStream studyStream)
        {
            return _studyStreamRepository.Update(studyStream);
        }

        public StudyStream RemoveStudyStream(StudyStream studyStream)
        {
            return _studyStreamRepository.Delete(studyStream);
        }

        public StudyStream RemoveStudyStream(int id)
        {
            return _studyStreamRepository.Delete(id);
        }

        public void RegisterOGNP(StudentExtra student, StudyStream studyStream)
        {
            if (studyStream.Students == null || studyStream.LimitStudents > studyStream.Students.Count)
            {
                if (student.Pairs == null)
                {
                    student.Pairs = new List<Pair>();
                }

                if (studyStream.Pairs != null)
                {
                    student.Pairs.AddRange(studyStream.Pairs);
                    _studentRepository.Update(student);
                }

                if (studyStream.Students == null)
                {
                    studyStream.Students = new List<StudentExtra>();
                }

                studyStream.Students.Add(student);
                _studyStreamRepository.Update(studyStream);

                return;
            }

            throw new IsuException("Study Stream has been enough students!");
        }

        public void UnRegisterOGNP(StudentExtra student, OGNP ognp)
        {
            foreach (StudyStream studyStream in GetStudyStreams(ognp))
            {
                if (studyStream.Students != null)
                {
                    studyStream.Students.Remove(student);
                    _studyStreamRepository.Update(studyStream);

                    return;
                }
            }
        }

        public List<StudyStream> GetStudyStreams(OGNP ognp)
        {
            return _studyStreamRepository.GetStudyStreams(ognp);
        }

        public List<StudentExtra> GetStudentsRegistered(OGNP ognp)
        {
            var students = new List<StudentExtra>();
            foreach (StudyStream studyStream in _studyStreamRepository.GetStudyStreams(ognp))
            {
                if (studyStream.Students != null)
                {
                    students.AddRange(studyStream.Students);
                }
            }

            return students;
        }

        public List<StudentExtra> GetStudentsUnRegistered(GroupExtra group)
        {
            var registeredStudents = new List<StudentExtra>();
            foreach (StudyStream studyStream in _studyStreamRepository.GetAll())
            {
                if (studyStream.Students != null)
                {
                    registeredStudents.AddRange(studyStream.Students);
                }
            }

            var unRegisteredStudents = new List<StudentExtra>();
            foreach (StudentExtra student in _studentRepository.FindStudents(group))
            {
                if (!registeredStudents.Contains(student))
                {
                    unRegisteredStudents.Add(student);
                }
            }

            return unRegisteredStudents;
        }
    }
}