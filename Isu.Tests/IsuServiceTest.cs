using Isu.Model;
using Isu.Service;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService();

            _isuService.AddGroup(new GroupName("M3211"));
            _isuService.AddGroup(new GroupName("M3212"));
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            var group = _isuService.FindGroup(new GroupName("M3211"));

            _isuService.AddStudent(group, "Student 1");

            var student = _isuService.GetStudent(1);

            Assert.IsNotNull(student);
            Assert.AreEqual(student.Id, 1);
            Assert.AreEqual(student.Name, "Student 1");
            Assert.AreEqual(student.Group.GroupName.Name, "M3211");
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            var group = _isuService.FindGroup(new GroupName("M3211"));

            _isuService.AddStudent(group, "Student 1");
            _isuService.AddStudent(group, "Student 2");

            var students = _isuService.FindStudents(new GroupName("M3211"));

            Assert.AreEqual(students.Count, 2);
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            try
            {
                _isuService.AddGroup(new GroupName("M3511"));
                Assert.Fail();
            }
            catch (IsuException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            var group = _isuService.FindGroup(new GroupName("M3211"));
            var student = _isuService.AddStudent(group, "Student 1");

            var newgroup = _isuService.FindGroup(new GroupName("M3212"));

            _isuService.ChangeStudentGroup(student, newgroup);

            Assert.AreEqual(student.Group.GroupName, newgroup.GroupName);
        }
    }
}