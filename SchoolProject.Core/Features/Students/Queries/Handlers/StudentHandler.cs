using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Queries.Handlers;

public class StudentHandler(IStudentService studentService, IMapper mapper) : IRequestHandler<GetStudentListQuery, List<GetStudentListResponse>>
{
    private readonly IStudentService _studentService = studentService;
    private readonly IMapper _mapper = mapper;


    public async Task<List<GetStudentListResponse>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentService.GetAllStudentsAsync();
        var studentListResponses = _mapper.Map<List<GetStudentListResponse>>(students);

        return studentListResponses;
    }
}