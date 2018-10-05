using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {   

            private readonly IUserService _service;
            public UsersController(IUserService service)
            {
                _service = service;
            }

    [HttpGet]
        public async Task<IActionResult> GetAll()
    {
            var result = await _service.GetAll();
            if(result.Any())
            {
                return Ok(_service.GetAll());
            }else
            {
                return NotFound();
            }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetJob(id));
    }

    }
}