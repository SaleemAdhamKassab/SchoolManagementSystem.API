using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;

namespace SchoolProject.Infrastructure.Repositories;

public class StudentRepository(ApplicationDbContext db) : GenericRepository<Student>(db), IStudentRepository
{
    private readonly DbSet<Student> _students = db.Set<Student>();

    public async Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken)
    {
        return await _students
            .Include(s => s.Department)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}