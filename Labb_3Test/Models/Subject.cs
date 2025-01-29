using System;
using System.Collections.Generic;

namespace Labb_3.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string? Subjects { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
