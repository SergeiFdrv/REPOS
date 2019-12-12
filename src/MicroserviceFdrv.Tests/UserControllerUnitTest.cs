using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using MicroserviceFdrv.Controllers;

namespace MicroserviceFdrv.Tests
{
    public class UserControllerUnitTest
    {
        private UserController controller;
        //private SqlConnection _connection = null;

        public UserControllerUnitTest()
        {
            controller = new UserController();
            controller.ConnectionString = @"Data Source=KONDR-244\MSSQLSERVER01; Initial Catalog=Konspekt; Integrated Security=true";
        }

        [Fact]
        public void Register()
        {
            // Arrange
            string username = "user";

            // Act
            IActionResult result = controller.Register(username);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void RegisterWithPassword()
        {
            // Arrange
            string username = "user0", password = "asd";

            // Act
            IActionResult result = controller.Register(username, password);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Login()
        {
            // Arrange
            string username = "user";

            // Act
            IActionResult result = controller.Login(username);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void LoginPassword()
        {
            // Arrange
            string username = "user0", password = "asd";

            // Act
            IActionResult result = controller.Login(username, password);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void LoginWrong()
        {
            // Arrange
            string username = "user0", password = "a";

            // Act
            IActionResult result = controller.Login(username, password);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Logout()
        {
            // Arrange
            int id = 1;

            // Act
            IActionResult result = controller.Logout(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
