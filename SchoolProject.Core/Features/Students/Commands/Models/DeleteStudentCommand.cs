using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Students.Commands.Models;

public class DeleteStudentCommand(int id) : IRequest<Response<string>>
{
    public int Id { get; set; } = id;
}