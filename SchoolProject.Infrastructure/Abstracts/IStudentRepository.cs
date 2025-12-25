using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Abstracts;

public interface IStudentRepository
{
    Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken);
}