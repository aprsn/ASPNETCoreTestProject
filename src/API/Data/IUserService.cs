using System.Collections.Generic;
using System.Threading.Tasks;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Data
{
    public interface IUserService
    {
        Task<IEnumerable<UserView>> GetAll();
        Task<IActionResult> GetName(int id);
        Task<IEnumerable<UserView>> GetJob(int id);
    }
}