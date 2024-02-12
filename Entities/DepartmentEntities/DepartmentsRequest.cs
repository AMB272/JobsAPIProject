using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPIProject.Entities.DepartmentEntities
{
    public class DepartmentsRequest
    {
        public int DepartmentId { get; set; }
        public string? DepartmentTitle { get; set; }
    }
}