using System;
using System.Collections.Generic;

namespace Labb_3.Models;

public partial class TeacherSubject
{
    public int Id { get; set; }

    public int? TeacherId { get; set; }

    public int? SubjectId { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual SchoolRole? Teacher { get; set; }
}
