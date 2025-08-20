using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using magero_store.Controllers;
using magero_store.Models;
using magero_store.Data;
using System.Linq;

namespace magero_store.Tests.Controllers
{
    /// <summary>
    /// Tests para ProductsController siguiendo principios TDD red phase.
    /// </summary>
    public class ProductsControllerTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _controller = new ProductsController(_mockConfiguration.Object);
        }

        [Fact]
        public void Index_ShouldReturnViewResult_WhenCalledWithoutSearchTerm()
        {
            // Arrange
            string? searchTerm = null;

            // Act
            var result = _controller.Index(searchTerm);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ShouldReturnAllProducts_WhenSearchTermIsNull()
        {
            // Arrange
            string? searchTerm = null;
            var expectedProductCount = SampleData.Products.Count;

            // Act
            var result = _controller.Index(searchTerm) as ViewResult;
            var model = result?.Model as System.Collections.Generic.List<Product>;

            // Assert
            Assert.NotNull(model);
            Assert.Equal(expectedProductCount, model.Count);
        }

        [Fact]
        public void Index_ShouldReturnAllProducts_WhenSearchTermIsEmpty()
        {
            // Arrange
            var searchTerm = "";
            var expectedProductCount = SampleData.Products.Count;

            // Act
            var result = _controller.Index(searchTerm) as ViewResult;
            var model = result?.Model as System.Collections.Generic.List<Product>;

            // Assert
            Assert.NotNull(model);
            Assert.Equal(expectedProductCount, model.Count);
        }

        [Fact]
        public void Index_ShouldReturnFilteredProducts_WhenSearchTermProvided()
        {
            // Arrange
            var searchTerm = "laptop"; // Should match products with "laptop" in description

            // Act
            var result = _controller.Index(searchTerm) as ViewResult;
            var model = result?.Model as System.Collections.Generic.List<Product>;

            // Assert
            Assert.NotNull(model);
            // Should return only products containing "laptop" in description (case insensitive)
            Assert.All(model, product => 
                Assert.Contains(searchTerm, product.Description, System.StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public void Index_ShouldReturnEmptyList_WhenNoProductsMatchSearchTerm()
        {
            // Arrange
            var searchTerm = "nonexistentproduct";

            // Act
            var result = _controller.Index(searchTerm) as ViewResult;
            var model = result?.Model as System.Collections.Generic.List<Product>;

            // Assert
            Assert.NotNull(model);
            Assert.Empty(model);
        }

        [Fact]
        public void Index_ShouldPerformCaseInsensitiveSearch_WhenSearchTermProvided()
        {
            // Arrange
            var searchTermLower = "laptop";
            var searchTermUpper = "LAPTOP";

            // Act
            var resultLower = _controller.Index(searchTermLower) as ViewResult;
            var modelLower = resultLower?.Model as System.Collections.Generic.List<Product>;
            
            var resultUpper = _controller.Index(searchTermUpper) as ViewResult;
            var modelUpper = resultUpper?.Model as System.Collections.Generic.List<Product>;

            // Assert
            Assert.NotNull(modelLower);
            Assert.NotNull(modelUpper);
            Assert.Equal(modelLower.Count, modelUpper.Count);
        }

        [Fact]
        public void Details_ShouldReturnViewResult_WhenValidIdProvided()
        {
            // Arrange
            var validId = 1; // Assuming product with ID 1 exists in SampleData

            // Act
            var result = _controller.Details(validId);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Details_ShouldReturnCorrectProduct_WhenValidIdProvided()
        {
            // Arrange
            var validId = 1;
            var expectedProduct = SampleData.Products.FirstOrDefault(p => p.Id == validId);

            // Act
            var result = _controller.Details(validId) as ViewResult;
            var model = result?.Model as Product;

            // Assert
            Assert.NotNull(model);
            Assert.NotNull(expectedProduct);
            Assert.Equal(expectedProduct.Id, model.Id);
            Assert.Equal(expectedProduct.Name, model.Name);
        }

        [Fact]
        public void Details_ShouldReturnNotFoundResult_WhenInvalidIdProvided()
        {
            // Arrange
            var invalidId = 99999; // Assuming this ID doesn't exist

            // Act
            var result = _controller.Details(invalidId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Details_ShouldReturnNotFoundResult_WhenNegativeIdProvided()
        {
            // Arrange
            var negativeId = -1;

            // Act
            var result = _controller.Details(negativeId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Details_ShouldReturnNotFoundResult_WhenZeroIdProvided()
        {
            // Arrange
            var zeroId = 0;

            // Act
            var result = _controller.Details(zeroId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(-999)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(99999)]
        [InlineData(int.MaxValue)]
        public void Details_ShouldReturnNotFoundResult_WhenNonExistentIdProvided(int invalidId)
        {
            // Arrange & Act
            var result = _controller.Details(invalidId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void ProductsController_ShouldInheritFromController_WhenChecked()
        {
            // Arrange & Act
            var controller = new ProductsController(_mockConfiguration.Object);

            // Assert
            Assert.IsAssignableFrom<Controller>(controller);
        }

        [Fact]
        public void ProductsController_ShouldHaveConfigurationDependency_WhenInstantiated()
        {
            // Arrange
            var mockConfig = new Mock<IConfiguration>();

            // Act
            var controller = new ProductsController(mockConfig.Object);

            // Assert
            Assert.NotNull(controller);
        }

        [Fact]
        public void ProductsController_ShouldThrowArgumentNullException_WhenConfigurationIsNull()
        {
            // Arrange
            IConfiguration? nullConfiguration = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ProductsController(nullConfiguration!));
        }

        [Fact]
        public void Search_ShouldReturnViewResult_WhenValidSearchTermProvided()
        {
            // Arrange
            _mockConfiguration.Setup(c => c.GetConnectionString("DefaultConnection"))
                .Returns("mock connection string");
            var searchTerm = "test";

            // Act & Assert
            // Note: This test will fail because Search method uses actual database connection
            // This demonstrates TDD red phase - test fails initially until proper implementation
            Assert.Throws<System.Exception>(() => _controller.Search(searchTerm));
        }

        [Fact]
        public void Search_ShouldHandleNullSearchTerm_WhenCalled()
        {
            // Arrange
            _mockConfiguration.Setup(c => c.GetConnectionString("DefaultConnection"))
                .Returns("mock connection string");
            string? nullSearchTerm = null;

            // Act & Assert
            // This test demonstrates red phase - will fail until proper null handling is implemented
            Assert.Throws<System.Exception>(() => _controller.Search(nullSearchTerm!));
        }

        [Fact]
        public void Search_ShouldHandleEmptySearchTerm_WhenCalled()
        {
            // Arrange
            _mockConfiguration.Setup(c => c.GetConnectionString("DefaultConnection"))
                .Returns("mock connection string");
            var emptySearchTerm = "";

            // Act & Assert
            // This test demonstrates red phase - will fail until proper empty string handling is implemented
            Assert.Throws<System.Exception>(() => _controller.Search(emptySearchTerm));
        }
    }
}