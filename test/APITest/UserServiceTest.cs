using System;
using System.Collections.Generic;
using System.Linq;
using API.Controllers;
using API.Data;
using API.Models;
using API.Services;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;


namespace APITest
{
    public class UserServiceTest
    {

        [Fact]
        public async void GetAll_ReturnsUsers()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetAll()).ReturnsAsync(() => new List<User>(){
                new User() { Id = 1, Name = "Alper", Lastname = "San" , Job = "Engineer"},
                new User() { Id = 2, Name = "Alper2", Lastname = "San" , Job = "Engineer"},
                new User() { Id = 3, Name = "Alper3", Lastname = "San" , Job = "Engineer"},
                new User() { Id = 4, Name = "Mete", Lastname = "Pakdil" , Job = "Engineer"}
            });
            var userService = new UserService(mockUserRepository.Object);

            var result = await userService.GetAll();
            Assert.Equal(4,result.Count());
            Assert.Equal("Alper San" , result.FirstOrDefault().FullName);
            Assert.Equal("Mete Pakdil" , result.LastOrDefault().FullName);
   
        } 

        [Fact]
        public async void GetAll_ReturnsEmpty()
        {
            var mockUserRepository = new Mock<IUserRepository>();
          
            var userService = new UserService(mockUserRepository.Object);

            var result = await userService.GetAll();
            Assert.Empty(result);
        }
    }
}
