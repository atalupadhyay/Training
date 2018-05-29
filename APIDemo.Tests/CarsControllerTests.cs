using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using APIDemo.Services;
using APIDemo.Controllers;
using System.Collections.Generic;
using APIDemo.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APIDemo.Tests
{
    public class CarsControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithCarsRepository()
        {
            // Arrange
            var mockRepo = new Mock<ICarsRepository>();

            mockRepo.Setup(x => x.GetAll())
                .Returns(GetCars);

            // Act
            var ctrl = new CarsController(mockRepo.Object);
            var result = await ctrl.GetAllCars();

            // Assert
            Assert.NotNull(result);

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var cars = okResult.Value.Should().BeAssignableTo<IEnumerable<Car>>().Subject;
            cars.Count().Should().Be(1);

        }

        private async Task<IEnumerable<Car>> GetCars()
        {
            return await Task.Run(() =>

            new List<Car>()
                {
                new Car()
                {
                    Id = 1,
                    BrandName = 0,
                    ModelName = "Delorian",
                    YearOfConstruction = 1985,
                    IdentificationNumber = Guid.NewGuid()
                }
            });
        }
    }
}
