using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;


    public int DepartmentId { get; set; }
    public Department Department { get; set; } = default!;

    public ICollection<StudentSubject> StudentSubjects { get; set; } = [];
}