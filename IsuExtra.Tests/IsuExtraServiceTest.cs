using Isu.Model;
using IsuExtra.Model;
using IsuExtra.Services;
using IsuExtra.Services.Infrastructure;
using NUnit.Framework;

namespace IsuExtra.Tests
{
    [TestFixture]
    public class IsuExtraServiceTest
    {
        private IStudentService _studentService;
        private IGroupService _groupService;
        private IIsuExtraService _isuExtraService;

        [SetUp]
        public void Setup()
        {
            _studentService = new StudentService();
            _groupService = new GroupService();
            _isuExtraService = new IsuExtraService();

            _groupService.AddGroup(new GroupName("M3210"));
            _groupService.AddGroup(new GroupName("M3211"));

            _studentService.AddStudent(_groupService.GetGroup(1), "Student 1");
            _studentService.AddStudent(_groupService.GetGroup(2), "Student 2");
            _studentService.AddStudent(_groupService.GetGroup(1), "Student 3");

            _isuExtraService.AddOGNP(new OGNP("OGNP 1", 'M'));
            _isuExtraService.AddOGNP(new OGNP("OGNP 2", 'M'));

            _isuExtraService.AddStudyStream(new StudyStream(_isuExtraService.GetOGNP(1), 20));
            _isuExtraService.AddStudyStream(new StudyStream(_isuExtraService.GetOGNP(1), 30));
        }

        [Test]
        public void RegisterOGNP()
        {
            StudentExtra student = _studentService.GetStudent(1);
            StudyStream studyStream = _isuExtraService.GetStudyStream(1);
            _isuExtraService.RegisterOGNP(student, studyStream);

            Assert.IsTrue(studyStream.Students.Contains(student));
        }

        [Test]
        public void UnRegisterOGNP()
        {
            StudentExtra student = _studentService.GetStudent(1);
            StudyStream studyStream = _isuExtraService.GetStudyStream(1);
            _isuExtraService.RegisterOGNP(student, studyStream);

            _isuExtraService.UnRegisterOGNP(student, _isuExtraService.GetOGNP(1));
            Assert.IsFalse(studyStream.Students.Contains(student));
        }

        [Test]
        public void GetStudyStreamsByOGNP()
        {
            var studyStreams = _isuExtraService.GetStudyStreams(_isuExtraService.GetOGNP(1));

            Assert.AreEqual(studyStreams.Count, 2);
        }

        [Test]
        public void GetStudentsRegisteredByOGNP()
        {
            _isuExtraService.RegisterOGNP(_studentService.GetStudent(1), _isuExtraService.GetStudyStream(1));
            _isuExtraService.RegisterOGNP(_studentService.GetStudent(2), _isuExtraService.GetStudyStream(2));

            var students = _isuExtraService.GetStudentsRegistered(_isuExtraService.GetOGNP(1));

            Assert.AreEqual(students.Count, 2);
        }

        [Test]
        public void GetStudentsUnRegisteredByGroup()
        {
            _isuExtraService.RegisterOGNP(_studentService.GetStudent(1), _isuExtraService.GetStudyStream(1));

            var students = _isuExtraService.GetStudentsUnRegistered(_groupService.GetGroup(1));

            Assert.AreEqual(students.Count, 1);
        }
    }
}

