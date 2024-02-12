using System;
using System.Collections.Generic;

namespace JobsAPIProject.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string? LocationTitle { get; set; }

    public string? LocationCity { get; set; }

    public string? LocationState { get; set; }

    public string? LocationCountry { get; set; }

    public int? LocationZip { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
