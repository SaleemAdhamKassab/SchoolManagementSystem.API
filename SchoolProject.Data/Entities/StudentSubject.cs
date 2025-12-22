using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities;

public class StudentSubject
{
    [Key]
    public int Id { get; set; }


    public int StudentId { get; set; }
    public Student Student { get; set; } = default!;

    public int SubjectId { get; set; }
    public Subject Subject { get; set; } = default!;
}