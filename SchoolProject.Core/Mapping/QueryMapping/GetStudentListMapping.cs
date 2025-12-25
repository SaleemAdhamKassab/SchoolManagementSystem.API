using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;


namespace SchoolProject.Core.Mapping.Students;

public partial class StudentProfile
{
    public void GetStudentListMapping()
    {
        CreateMap<Student, GetStudentListResponse>()
           .ForMember(dst => dst.Department, options => options.MapFrom(src => src.Department.Name));
    }
}