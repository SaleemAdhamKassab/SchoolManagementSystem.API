using MediatR;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Queries.Handlers;

public class StudentHandler(IStudentService studentService) : IRequestHandler<GetStudentListQuery, List<Student>>
{
    private readonly IStudentService _studentService = studentService;

    public async Task<List<Student>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
    {
        return await _studentService.GetAllStudentsAsync();
    }
}