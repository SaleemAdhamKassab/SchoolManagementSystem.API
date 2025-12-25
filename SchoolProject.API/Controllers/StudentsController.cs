using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Queries.Models;

namespace SchoolProject.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var response = await _mediator.Send(new GetStudentListQuery());

        return Ok(response);
    }
}