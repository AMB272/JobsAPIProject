using JobsAPIProject.Entities.JobEntities;

namespace JobsAPIProject.Repository.Contracts
{
    public interface IJobsRepository
    {
        Task<int> InsertJobEntry(JobsRequest request);
        Task<int> UpdateJobEntry(int id, JobsRequest request);
        Task<JobsListResponse> ListAllJobs(JobsListRequest request);
        Task<JobsDetailsResponse> GetJobDetails(int id);

    }
}