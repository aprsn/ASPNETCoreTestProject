using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetJob(int id)
        {
            return await _context.Users.Where(p => p.Id == id).ToListAsync();
        }

        public async Task<User> GetName(int id)
        {
            return await _context.Users.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}