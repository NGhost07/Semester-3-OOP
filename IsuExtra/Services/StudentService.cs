using Isu.Tools;
using IsuExtra.Database.Infrastructure;
using IsuExtra.Database.Repositories;
using IsuExtra.Model;
using IsuExtra.Services.Infrastructure;

namespace IsuExtra.Services
{
    public class StudentService
        : IStudentService
    {
        private readonly IStudentExtraRepository _studentExtraRepository;
        private readonly IPairRepository _pairRepository;
        private readonly IGroupExtraRepository _groupExtraRepository;

        public StudentService()
        {
            _studentExtraRepository = StudentExtraRepository.GetInstance();
            _pairRepository = PairRepository.GetInstance();
            _groupExtraRepository = GroupExtraRepository.GetInstance();
        }

        public StudentExtra AddStudent(GroupExtra groupExtra, string name)
        {
            if (!_groupExtraRepository.GetAll().Contains(groupExtra))
            {
                throw new IsuException("This Group is not existed!");
            }

            var student = new StudentExtra(groupExtra, name);
            if (_pairRepository.GetPairs(groupExtra) != null)
            {
                student.Pairs.AddRange(_pairRepository.GetPairs(groupExtra));
            }

            _studentExtraRepository.Add(student);

            return student;
        }

        public StudentExtra GetStudent(int id)
        {
            return _studentExtraRepository.GetById(id);
        }

        public StudentExtra RemoveStudent(StudentExtra student)
        {
            return _studentExtraRepository.Delete(student);
        }

        public StudentExtra RemoveStudent(int id)
        {
            return _studentExtraRepository.Delete(id);
        }

        public StudentExtra UpdateStudent(StudentExtra student)
        {
            return _studentExtraRepository.Update(student);
        }
    }
}