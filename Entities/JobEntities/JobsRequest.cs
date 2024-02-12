using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPIProject.Entities.JobEntities
{
    public class JobsRequest
    {
    public string? JobTitle { get; set; }
    public string? JobDescription { get; set; }
    public DateTime? ClosingDate { get; set; }
    public int? LocationId { get; set; }
    public int? DepartmentId { get; set; }
    }
}