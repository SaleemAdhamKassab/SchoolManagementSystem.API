using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students;

public partial class StudentProfile
{
    public void AddStudentMapping()
    {
        CreateMap<AddStudentCommand, Student>();
    }
}