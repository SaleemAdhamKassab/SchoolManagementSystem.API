using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities;

public class Department
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;




    public ICollection<Student> Students { get; set; } = [];
    public ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = [];
}
