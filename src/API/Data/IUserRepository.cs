using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IUserRepository
    {
         Task<User> GetName(int id);
         Task<IEnumerable<User>> GetJob(int id);
         Task<IEnumerable<User>> GetAll();
    }
}