using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPIProject.Entities.JobEntities
{
    public class JobsListResponse
    {
        public int Total { get; set; }
        public List<JobsEntity>? Data { get; set; }
    }

    public class JobsEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Department { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}