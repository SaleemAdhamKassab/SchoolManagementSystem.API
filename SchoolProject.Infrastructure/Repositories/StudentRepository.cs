using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;

namespace SchoolProject.Infrastructure.Repositories;

public class StudentRepository(ApplicationDbContext db) : IStudentRepository
{
    private readonly ApplicationDbContext _db = db;

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _db.Students.ToListAsync();
    }
}