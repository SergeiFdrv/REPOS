using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using MicroserviceFdrv.Controllers;
using System.Data.SqlClient;

namespace MicroserviceFdrv.Tests
{
    public class PCControllerUnitTest
    {
        private PCController controller;
        //private SqlConnection _connection = null;

        public PCControllerUnitTest()
        {
            controller = new PCController();
            controller.ConnectionString = @"Data Source=KONDR-244\MSSQLSERVER01; Initial Catalog=Computers; Integrated Security=true";
        }

        [Fact]
        public void Get_ReturnsJson()
        {
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
