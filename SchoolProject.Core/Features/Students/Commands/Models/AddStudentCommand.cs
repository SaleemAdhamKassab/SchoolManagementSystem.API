using MediatR;
using SchoolProject.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public int DepartmentId { get; set; }
    }
}