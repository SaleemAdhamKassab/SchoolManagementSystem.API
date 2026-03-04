using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts;

public interface IStudentService
{
    Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken);
    Task<Student?> GetStudentByIdAsync(int id, CancellationToken cancellationToken);
    Task<string> AddAsync(Student student, CancellationToken cancellationToken);
    Task<bool> IsFullNameExist(string fullName);
}