using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsAPIProject.Models;
using JobsAPIProject.Entities.DepartmentEntities;

namespace JobsAPIProject.Repository.Contracts
{
    public interface IDepartmentsRepository
    {
        //Interfaces added as part of 'Repository' Design Pattern
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<DepartmentEntity> InsertDepartment(DepartmentEntity location);
        Task<DepartmentEntity> UpdateDepartment(int id, DepartmentEntity locationChanges); 
    }
}