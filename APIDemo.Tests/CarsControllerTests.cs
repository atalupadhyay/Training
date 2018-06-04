using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;
using Moq;
using FluentAssertions;
using APIDemo.Services;
using APIDemo.Controllers;
using APIDemo.Models;

namespace APIDemo.Tests
{
    public class CarsControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithCarsRepository()
        {
            #region Arrange
            var mockRepo = new Mock<ICarsRepository>();

            mockRepo.Setup(x => x.GetAll(null))
                .Returns(GetCars);
            #endregion

            #region Act
            var ctrl = new CarsController(mockRepo.Object, null);
            var result = await ctrl.GetAllCars();
            #endregion

            #region Assert
            Assert.NotNull(result);

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var cars = okResult.Value.Should().BeAssignableTo<IEnumerable<Car>>().Subject;
            cars.Count().Should().Be(1);
            #endregion
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
