using System;
using System.Collections.Generic;

namespace Labb_3.Models;

public partial class SchoolRole
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Ssn { get; set; }

    public int? StaffId { get; set; }

    public virtual StaffRole? Staff { get; set; }

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
