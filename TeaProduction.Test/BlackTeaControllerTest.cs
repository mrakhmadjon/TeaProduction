using Microsoft.AspNetCore.Mvc;
using TeaProduction.API.Controllers;
using TeaProduction.Business.DTOs;
using TeaProduction.Business.Interfaces;
using TeaProduction.Business.Services;

namespace TeaProduction.Test
{
    public class BlackTeaControllerTest
    {
        private readonly BlackTeaController blackTeaController;
        private readonly IBlackTeaInterface blackTeaInterface;

        public BlackTeaControllerTest()
        {
            this.blackTeaInterface = new FakeBlackTeaService();
            this.blackTeaController = new BlackTeaController(blackTeaInterface);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = blackTeaController.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = blackTeaController.Get() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<BlackTeaDto>>(okResult?.Value);
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = blackTeaController.Get(30);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            int testId = 2;

            // Act
            var okResult = blackTeaController.Get(testId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            int testId = 2;


            // Act
            var okResult = blackTeaController.Get(testId) as OkObjectResult;

            // Assert
            Assert.IsType<BlackTeaDto>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as BlackTeaDto).Id);
        }


        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            int notExistingGuid = 2;

            // Act
            var badResponse = blackTeaController.Remove(notExistingGuid);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsNoContentResult()
        {
            // Arrange
            int existingGuid = 2;

            // Act
            var noContentResponse = blackTeaController.Remove(existingGuid);

            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            int existingGuid = 2;

            // Act
            var okResponse = blackTeaController.Remove(existingGuid);

            // Assert
            Assert.Equal(4, blackTeaInterface.GetAll().Count());
        }
    }
}
