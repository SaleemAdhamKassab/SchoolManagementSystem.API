using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Abstracts;

public interface IStudentRepository: IGenericRepository<Student>
{
    Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken);
}