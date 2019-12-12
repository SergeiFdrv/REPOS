using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using MicroserviceFdrv.Controllers;

namespace MicroserviceFdrv.Tests
{
    public class UserControllerUnitTest
    {
        [Fact]
        public void Register()
        {
            // Arrange
            UserController controller = new UserController();
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
            UserController controller = new UserController();
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
            UserController controller = new UserController();
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
            UserController controller = new UserController();
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
            UserController controller = new UserController();
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
            UserController controller = new UserController();
            int id = 1;

            // Act
            IActionResult result = controller.Logout(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
