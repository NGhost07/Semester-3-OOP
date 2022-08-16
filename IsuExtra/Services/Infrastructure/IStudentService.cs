using IsuExtra.Model;

namespace IsuExtra.Services.Infrastructure
{
    public interface IStudentService
    {
        StudentExtra AddStudent(GroupExtra groupExtra, string name);
        StudentExtra GetStudent(int id);
        StudentExtra RemoveStudent(StudentExtra student);
        StudentExtra RemoveStudent(int id);
        StudentExtra UpdateStudent(StudentExtra student);
    }
}