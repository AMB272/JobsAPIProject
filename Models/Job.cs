using System;
using System.Collections.Generic;

namespace JobsAPIProject.Models;

public partial class Job
{
    public int JobId { get; set; }

    public string? JobTitle { get; set; }

    public string? JobDescription { get; set; }

    public DateTime? PostedDate { get; set; }

    public DateTime? ClosingDate { get; set; }

    public int? LocationId { get; set; }

    public int? DepartmentId { get; set; }

    public string? JobCode { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Location? Location { get; set; }
}
