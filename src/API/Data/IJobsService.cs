using System.Collections.Generic;
using System.Threading.Tasks;
using API.ViewModels;

namespace API.Data
{
    public interface IJobsService 
    {
         Task<IEnumerable<JobsView>> GetAll();
         
         Task<IEnumerable<JobsView>> GetJob(int id);
    }
}