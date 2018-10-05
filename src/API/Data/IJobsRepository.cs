using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IJobsRepository
    {
         Task<IEnumerable<Jobs>> GetAllJobs();
         Task<IEnumerable<Jobs>> GetJob(int id); 
    }
}