using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsAPIProject.Entities.DepartmentEntities;
using JobsAPIProject.Models;
using JobsAPIProject.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace JobsAPIProject.Repository
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly JobsDbContext context;

        public DepartmentsRepository(JobsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await context.Departments.ToListAsync();
        }

        public async Task<DepartmentEntity> InsertDepartment(DepartmentEntity department)
        {
            var newDepartment = new Department
            {
                DepartmentTitle = department.Title ?? ""
            };
            await context.Departments.AddAsync(newDepartment);
            await context.SaveChangesAsync();
            return department;
        }

        public async Task<DepartmentEntity> UpdateDepartment(int id, DepartmentEntity departmentChanges)
        {
            var departmentRecord = await context.Departments.Where(x => x.DepartmentId == id).FirstOrDefaultAsync();
            if (departmentRecord != null)
            {
                if (departmentChanges.Title != departmentRecord.DepartmentTitle){
                    departmentRecord.DepartmentTitle = departmentChanges.Title;
                }
                await context.SaveChangesAsync();
            }
            return departmentChanges;
        }
    }
}