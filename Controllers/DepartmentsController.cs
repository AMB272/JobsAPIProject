using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobsAPIProject.Repository.Contracts;
using JobsAPIProject.Entities.DepartmentEntities;

namespace JobsAPIProject.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsRepository _departmentsRepository;

        public DepartmentsController(IDepartmentsRepository departmentsRepository)
        {
            _departmentsRepository = departmentsRepository;
        }

        /// <Summary>
        /// Inserts a new department entry based on parameters entered
        /// </Summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> InsertDepartment(DepartmentEntity department)
        {
            var response = await _departmentsRepository.InsertDepartment(department); 
            return new ObjectResult(response);
        }

        /// <Summary>
        /// Updates exisitng department entries
        /// </Summary>
        [HttpPut("{id:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> UpdateDepartment(int id, DepartmentEntity request)
        {
            var response = await _departmentsRepository.UpdateDepartment(id, request); 
            return new ObjectResult(response);
        }

        /// <Summary>
        /// Returns a list of all department entries present in the database
        /// </Summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> GetAllDepartments()
        {
            var response = await _departmentsRepository.GetAllDepartments(); 
            return new ObjectResult(response);
        }
    }
}