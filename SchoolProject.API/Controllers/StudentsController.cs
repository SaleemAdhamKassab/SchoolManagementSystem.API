using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers;

//[Route("api/[controller]")]
[ApiController]
public class StudentsController : AppControllerBase
{

    [HttpGet(Router.StudentRouting.List)]
    public async Task<IActionResult> GetAllStudents()
    {
        var response = await Mediator.Send(new GetStudentListQuery());
        return Ok(response);
    }


    [HttpGet(Router.StudentRouting.GetById)]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var response = await Mediator.Send(new GetStudentByIdQuery(id));
        return NewResult(response);
    }


    [HttpPost(Router.StudentRouting.Create)]
    public async Task<IActionResult> Create(AddStudentCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }


    [HttpPut(Router.StudentRouting.Edit)]
    public async Task<IActionResult> Edit(EditStudentCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
}