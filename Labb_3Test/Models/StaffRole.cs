using System;
using System.Collections.Generic;

namespace Labb_3.Models;

public partial class StaffRole
{
    public int Id { get; set; }

    public string? RoleType { get; set; }

    public virtual ICollection<SchoolRole> SchoolRoles { get; set; } = new List<SchoolRole>();
}
