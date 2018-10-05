using System;
using System.Collections.Generic;
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
    public class APIControllerTest
    {
        [Fact]
        public async void GetAll_ReturnsOkObjectResult()
        {
            var mockUserRepository = new Mock<IUserService>();
            mockUserRepository.Setup(repo => repo.GetAll()).ReturnsAsync(() => new List<UserView>(){
                new UserView() { Id = 1, FullName = "Alper San", JobDescription = "Engineer"},
            });
            var userService = new UsersController(mockUserRepository.Object);

            var result = await userService.GetAll();

            var OkObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<OkObjectResult>(OkObjectResult);
        }

        [Fact]
        public async void GetAll_ReturnsNotFoundObjectResult()
        {
            var mockUserRepository = new Mock<IUserService>();
  
            var userService = new UsersController(mockUserRepository.Object);

            var result = await userService.GetAll();

            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}
