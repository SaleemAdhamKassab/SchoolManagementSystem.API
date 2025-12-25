using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts;

public interface IStudentService
{
    Task<List<Student>> GetAllStudentsAsync();
}