using System;
using System.Collections.Generic;

namespace Labb_3.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public int? Age { get; set; }

    public string? Ssn { get; set; }

    public int? ClassId { get; set; }

    public string? Email { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
