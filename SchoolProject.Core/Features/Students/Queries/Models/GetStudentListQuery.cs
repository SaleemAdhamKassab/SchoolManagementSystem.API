using MediatR;
using SchoolProject.Core.Features.Students.Queries.Results;

namespace SchoolProject.Core.Features.Students.Queries.Models;

public class GetStudentListQuery: IRequest<List<GetStudentListResponse>>
{
}