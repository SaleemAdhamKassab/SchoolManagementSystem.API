using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<Subject> Subjects { get; set; } = default!;
    public DbSet<StudentSubject> StudentSubjects { get; set; } = default!;
    public DbSet<Department> Departments { get; set; } = default!;
    public DbSet<DepartmentSubject> DepartmentSubjects { get; set; } = default!;
}