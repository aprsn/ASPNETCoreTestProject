using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.ViewModels;

namespace API.Services
{
    public class JobsService : IJobsService
    {
        private readonly IJobsRepository _jobsRepository;
        public JobsService(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }
        public async Task<IEnumerable<JobsView>> GetAll()
        {
            IEnumerable<Jobs> jobs = await _jobsRepository.GetAllJobs();

            return jobs.Select(job => new JobsView{
                Id = job.Id,
                JobName = job.Job,
                JobInfo = job.JobDescription
            });
            
        }

        public async Task<IEnumerable<JobsView>> GetJob(int id)
        {
            IEnumerable<Jobs> jobs = await _jobsRepository.GetJob(id);

            return jobs.Select(job => new JobsView{
                Id = job.Id,
                JobName = job.Job,
                JobInfo = job.JobDescription
            });
        }
    }
}