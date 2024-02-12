using System;
using System.Collections.Generic;

namespace JobsAPIProject.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentTitle { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
