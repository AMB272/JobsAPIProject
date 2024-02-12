using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsAPIProject.Repository.Contracts;
using JobsAPIProject.Models;
using Microsoft.EntityFrameworkCore;
using JobsAPIProject.Entities.JobEntities;
using JobsAPIProject.Entities.LocationEntities;
using JobsAPIProject.Entities.DepartmentEntities;

namespace JobsAPIProject.Repository
{
    public class JobsRepository : IJobsRepository
    {
        private readonly JobsDbContext context;

        public JobsRepository(JobsDbContext context)
        {
            this.context = context;
        }

        public async Task<JobsDetailsResponse> GetJobDetails(int id)
        {
            var response = new JobsDetailsResponse();
            response = await(
                from j in context.Jobs.AsNoTracking()
                join l in context.Locations.AsNoTracking() on j.LocationId equals l.LocationId into lj
                from ljoin in lj.DefaultIfEmpty()
                join d in context.Departments.AsNoTracking() on j.DepartmentId equals d.DepartmentId into dj
                from djoin in dj.DefaultIfEmpty()
                where j.JobId == id
                select new JobsDetailsResponse
                {
                    Id = j.JobId,
                    Code = j.JobCode,
                    Title = j.JobTitle,
                    Description = j.JobDescription,
                    Location = new LocationEntity{
                        Id = ljoin.LocationId,
                        Title = ljoin.LocationTitle,
                        City = ljoin.LocationCity,
                        State = ljoin.LocationState,
                        Country = ljoin.LocationCountry,
                        Zip = ljoin.LocationZip
                    },
                    Department = new DepartmentEntity{
                        Id = djoin.DepartmentId,
                        Title = djoin.DepartmentTitle
                    },
                    PostedDate = j.PostedDate,
                    ClosingDate = j.ClosingDate
                }
            ).FirstOrDefaultAsync();
            if (response == null) { return null; }
            return response;
        }

        public async Task<int> InsertJobEntry(JobsRequest request)
        {
            var newJobEntry = new Job
            {
                JobTitle = request.JobTitle ?? "",
                JobDescription = request.JobDescription ?? "",
                LocationId = request.LocationId ?? 0,
                DepartmentId = request.DepartmentId ?? 0,
                ClosingDate = request.ClosingDate,
                PostedDate = DateTime.Now
            };
            await context.Jobs.AddAsync(newJobEntry);
            await context.SaveChangesAsync();
            return newJobEntry.JobId;
        }

        public async Task<JobsListResponse> ListAllJobs(JobsListRequest request)
        {
            var query = 
                from j in context.Jobs.AsNoTracking()
                select j
            ;

            if (!string.IsNullOrEmpty(request.Q))
                query = query.Where(a => a.JobTitle.ToLower().Contains(request.Q.ToLower()));

            if (request.DepartmentId > 0)
                query = query.Where(a => a.DepartmentId == request.DepartmentId);

            if (request.LocationId > 0)
                query = query.Where(a => a.LocationId == request.LocationId);

            var count = query.Count();

            var results = from q in query
            join l in context.Locations on q.LocationId equals l.LocationId
            join d in context.Departments on q.DepartmentId equals d.DepartmentId
            select new JobsEntity{
                Id = q.JobId, 
                Code = q.JobCode,
                Title = q.JobTitle,
                Location = l.LocationTitle,
                Department = d.DepartmentTitle,
                PostedDate = (DateTime) q.PostedDate, 
                ClosingDate = (DateTime) q.ClosingDate
            };

            var response = new JobsListResponse(){
                Total = count,
                Data = await results.Skip((request.PageNo - 1) * request.PageSize).Take(request.PageSize).ToListAsync()
            };
            return response;
        }

        public async Task<int> UpdateJobEntry(int id, JobsRequest request)
        {
            int isUpdated = 0;
            var JobRecord = await context.Jobs.Where(x => x.JobId == id).FirstOrDefaultAsync();
            if (JobRecord != null)
            {
                if (request.JobTitle != JobRecord.JobTitle){
                    JobRecord.JobTitle = request.JobTitle;
                }
                if (request.JobDescription != JobRecord.JobDescription){
                    JobRecord.JobDescription = request.JobDescription;
                }
                if (request.LocationId != JobRecord.LocationId){
                    JobRecord.LocationId = request.LocationId;
                }
                if (request.DepartmentId != JobRecord.DepartmentId){
                    JobRecord.DepartmentId = request.DepartmentId;
                }
                if (request.ClosingDate != JobRecord.ClosingDate){
                    JobRecord.ClosingDate = request.ClosingDate;
                }
                isUpdated = await context.SaveChangesAsync();
            }
            return isUpdated;
        }
    }
}