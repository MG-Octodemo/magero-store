using Xunit;
using Microsoft.AspNetCore.Mvc;
using magero_store.Controllers;
using magero_store.Models;
using magero_store.Data;

namespace magero_store.Tests.Controllers
{
    /// <summary>
    /// Tests para HomeController siguiendo principios TDD red phase.
    /// </summary>
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ShouldReturnViewResult_WhenCalled()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ShouldReturnViewWithProductsList_WhenCalled()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<System.Collections.Generic.List<Product>>(result.Model);
        }

        [Fact]
        public void Index_ShouldReturnSampleDataProducts_WhenCalled()
        {
            // Arrange
            var controller = new HomeController();
            var expectedProductCount = SampleData.Products.Count;

            // Act
            var result = controller.Index() as ViewResult;
            var model = result?.Model as System.Collections.Generic.List<Product>;

            // Assert
            Assert.NotNull(model);
            Assert.Equal(expectedProductCount, model.Count);
        }

        [Fact]
        public void Error_ShouldReturnViewResult_WhenCalled()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Error();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Error_ShouldReturnViewWithNoModel_WhenCalled()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Error() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Model);
        }

        [Fact]
        public void HomeController_ShouldInheritFromController_WhenChecked()
        {
            // Arrange & Act
            var controller = new HomeController();

            // Assert
            Assert.IsAssignableFrom<Controller>(controller);
        }

        [Fact]
        public void HomeController_ShouldHaveIndexMethod_WhenChecked()
        {
            // Arrange
            var controllerType = typeof(HomeController);

            // Act
            var indexMethod = controllerType.GetMethod("Index");

            // Assert
            Assert.NotNull(indexMethod);
            Assert.Equal(typeof(IActionResult), indexMethod.ReturnType);
        }

        [Fact]
        public void HomeController_ShouldHaveErrorMethod_WhenChecked()
        {
            // Arrange
            var controllerType = typeof(HomeController);

            // Act
            var errorMethod = controllerType.GetMethod("Error");

            // Assert
            Assert.NotNull(errorMethod);
            Assert.Equal(typeof(IActionResult), errorMethod.ReturnType);
        }
    }
}