using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPIProject.Entities.DepartmentEntities
{
    public class DepartmentsResponse
    {
        public List<DepartmentEntity>? LstDepartments { get; set; }
    }

    public class DepartmentEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}