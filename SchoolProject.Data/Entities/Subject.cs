using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities;

public class Subject
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public DateTime Period { get; set; }


    public ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = [];
    public ICollection<StudentSubject> StudentSubjects { get; set; } = [];
}