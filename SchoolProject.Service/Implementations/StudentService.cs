using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    private readonly IStudentRepository _studentRepository = studentRepository;


    public async Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken)
    {
        return await _studentRepository.GetAllStudentsAsync(cancellationToken);
    }

    public async Task<Student?> GetStudentByIdAsync(int id, CancellationToken cancellationToken)
    {
        var student = await _studentRepository
            .GetTableNoTracking()
            .Include(d => d.Department)
            .Where(s => s.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        return student;
    }

    public async Task<string> AddAsync(Student student, CancellationToken cancellationToken)
    {
        var studentResult = _studentRepository
            .GetTableNoTracking()
            .Where(e => e.FirstName == student.FirstName && e.LastName == student.LastName)
            .FirstOrDefault();

        if (studentResult != null)
            return "Exists";

        await _studentRepository.AddAsync(student, cancellationToken);


        return "Success";
    }
}