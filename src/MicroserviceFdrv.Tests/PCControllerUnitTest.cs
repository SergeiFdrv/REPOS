using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using MicroserviceFdrv.Controllers;

namespace MicroserviceFdrv.Tests
{
    public class PCControllerUnitTest
    {
        [Fact]
        public void Get_ReturnsJson()
        {
            // Arrange
            PCController controller = new PCController();

            // Act
            IActionResult get = controller.Get();

            // Assert
            Assert.IsType<JsonResult>(get);
        }

        [Fact]
        public void Set_ReturnsOk()
        {
            // Arrange
            PCController controller = new PCController();
            short model = 1101, speed = 10000, ram = 128, hd = 1000;
            string rd = "16xDVD";
            int price = 10000;

            // Act
            IActionResult get = controller.Add(model, speed, ram, hd, rd, price);

            // Assert
            Assert.IsType<OkObjectResult>(get);
        }
    }
}
