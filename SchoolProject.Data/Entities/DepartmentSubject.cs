using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities;

public class DepartmentSubject
{
    [Key]
    public int Id { get; set; }


    public int DepartmentId { get; set; }
    public Department Department { get; set; } = default!;

    public int SubjectId { get; set; }
    public Subject Subject { get; set; } = default!;
}