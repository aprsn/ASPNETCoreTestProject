    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using API.Data;
    using API.Models;
    using API.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    namespace API.Services
    {
        public class UserService : IUserService
        {
            private readonly IUserRepository _userRepository;

            public UserService(IUserRepository repo)
            {
                _userRepository = repo;   
            }

            public async Task<IEnumerable<UserView>> GetAll()
            {
                 IEnumerable<User> users = await _userRepository.GetAll();

                return users.Select(p => new UserView()
                 {
                   Id = p.Id,
                   FullName = p.Name + " " + p.Lastname,
                   JobDescription = p.Job
                 });
            }

            public async Task<IEnumerable<UserView>> GetJob(int id)
            {
                  IEnumerable<User> userInfo = await _userRepository.GetJob(id);

                  return userInfo.Select(p => new UserView()
                  {
                      Id = p.Id,
                      FullName = p.Name + " " + p.Lastname,
                      JobDescription = p.Job
                  });
            }

            public Task<IActionResult> GetName(int id)
            {
                throw new System.NotImplementedException();
            }
        }
    }