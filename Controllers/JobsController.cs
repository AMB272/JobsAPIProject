using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsAPIProject.Entities.JobEntities;
using JobsAPIProject.Repository.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JobsAPIProject.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class JobsController : ControllerBase
    {
        private readonly IJobsRepository _jobsRepository;

        public JobsController(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }

        /// <Summary>
        /// Adds a new Job Entry; returns 201 with location header
        /// </Summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<CreatedResult> InsertJobEntry(JobsRequest request)
        {
            var response = await _jobsRepository.InsertJobEntry(request);
            return Created(new Uri(Request.GetEncodedUrl()+ "/" + response), null);
        }

        /// <Summary>
        /// Updates an existing Job Entry; returns 200 OK status
        /// </Summary>
        [HttpPut("{id:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<OkResult> UpdateJobEntry(int id, JobsRequest request)
        {
            var response = await _jobsRepository.UpdateJobEntry(id, request);
            return Ok();
        }

        /// <Summary>
        /// Lists all the existing job entries in the database; querying and pagination parameters can be passed in the request object
        /// </Summary>
        [HttpPost("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> ListAllJobs(JobsListRequest request)
        {
            var response = await _jobsRepository.ListAllJobs(request);
            return new ObjectResult(response);
        }
        
        /// <Summary>
        /// returns details for a single job entry
        /// </Summary>
        [HttpGet("{id:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ObjectResult> GetJobDetails(int id)
        {
            var response = await _jobsRepository.GetJobDetails(id);
            return new ObjectResult(response);
        }
        
    }
}