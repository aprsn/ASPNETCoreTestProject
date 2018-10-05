using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {

        private readonly IJobsService _jobsService;
        public JobsController(IJobsService jobsService)
        {
           _jobsService = jobsService; 
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var result = await _jobsService.GetAll();

            if(result.Any())
            {
                return Ok(result);
            }
             return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var result = await _jobsService.GetJob(id);

            if(result.Any())
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}