using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using MicroserviceFdrv.Controllers;

namespace MicroserviceFdrv.Tests
{
    public class MathControllerUnitTest
    {
        [Fact]
        public void Sum_9_14_Returns23()
        {
            // Arrange
            MathController controller = new MathController();
            int x = 9, y = 14;

            // Act
            int result = controller.Sum(x, y);

            // Assert
            Assert.Equal(23, result);
        }

        [Fact]
        public void Difference_9_14_ReturnsNegative5()
        {
            // Arrange
            MathController controller = new MathController();
            int x = 9, y = 14;

            // Act
            int result = controller.Difference(x, y);

            // Assert
            Assert.Equal(-5, result);
        }

        [Fact]
        public void Product_9_14_Returns126()
        {
            // Arrange
            MathController controller = new MathController();
            int x = 9, y = 14;

            // Act
            int result = controller.Multiply(x, y);

            // Assert
            Assert.Equal(126, result);
        }

        [Fact]
        public void Division_9_14_Returns0()
        {
            // Arrange
            MathController controller = new MathController();
            int x = 9, y = 14;

            // Act
            int result = controller.Divide(x, y);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Division_14_9_Returns1()
        {
            // Arrange
            MathController controller = new MathController();
            int x = 14, y = 9;

            // Act
            int result = controller.Divide(x, y);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Division_126_14_Returns9()
        {
            // Arrange
            MathController controller = new MathController();
            int x = 126, y = 14;

            // Act
            int result = controller.Divide(x, y);

            // Assert
            Assert.Equal(9, result);
        }
    }
}
