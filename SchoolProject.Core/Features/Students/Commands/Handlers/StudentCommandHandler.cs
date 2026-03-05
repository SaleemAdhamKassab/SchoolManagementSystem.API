using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler(
        IStudentService studentService,
        IMapper mapper) :
        ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService = studentService;
        private readonly IMapper _mapper = mapper;


        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(studentMapper, cancellationToken);

            if (result == "Success")
                return Created("Added Successfully");

            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id, cancellationToken);

            if (student == null)
                return NotFound<string>($"Student with Id {request.Id} Not found!");

            var studentMapper = _mapper.Map<Student>(request);

            var result = await _studentService.EditAsync(studentMapper, cancellationToken);

            if (result == "Success")
                return Success($"Student with Id:{studentMapper.Id} edited successfully");

            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id, cancellationToken);

            if (student == null)
                return NotFound<string>($"Student with Id {request.Id} Not found!");

            var result = await _studentService.DeleteAsync(student, cancellationToken);

            if (result == "Success")
                return Deleted<string>($"Student deleted successfully");

            return BadRequest<string>();
        }
    }
}
