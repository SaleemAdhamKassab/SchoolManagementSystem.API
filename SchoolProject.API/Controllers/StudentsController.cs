using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers;

//[Route("api/[controller]")]
[ApiController]
public class StudentsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet(Router.StudentRouting.List)]
    public async Task<IActionResult> GetAllStudents()
    {
        var response = await _mediator.Send(new GetStudentListQuery());
        return Ok(response);
    }


    [HttpGet(Router.StudentRouting.GetById)]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var response = await _mediator.Send(new GetStudentByIdQuery(id));
        return Ok(response);
    }


    [HttpPost(Router.StudentRouting.Create)]
    public async Task<IActionResult> Create(AddStudentCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}