using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class AddStudentCommandHandler(
        IStudentService studentService,
        IMapper mapper) : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService = studentService;
        private readonly IMapper _mapper = mapper;


        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(studentMapper, cancellationToken);

            if (result == "Exists")
                return UnprocessableEntity<string>("Student already exists");
            else if (result == "Success")
                return Created("Added Successfully");
            else return BadRequest<string>();

        }
    }
}
