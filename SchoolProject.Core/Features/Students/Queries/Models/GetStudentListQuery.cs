using MediatR;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Students.Queries.Models;

public class GetStudentListQuery: IRequest<List<Student>>
{
}