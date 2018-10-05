using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class JobsRepository : IJobsRepository
    {
         private readonly DataContext _context;
        public JobsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Jobs>> GetAllJobs()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<IEnumerable<Jobs>> GetJob(int id)
        {
            return await _context.Jobs.Where(job => job.Id == id).ToListAsync();
        }
    }
}