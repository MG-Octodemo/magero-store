using Xunit;
using magero_store.Models;
using System.ComponentModel.DataAnnotations;

namespace magero_store.Tests.Models
{
    /// <summary>
    /// Tests básicos para el modelo Product siguiendo principios TDD red phase.
    /// Estos tests están diseñados para validar el comportamiento básico del modelo Product.
    /// </summary>
    public class ProductBasicTests
    {
        [Fact]
        public void Product_ShouldCreateInstance_WhenInstantiated()
        {
            // Arrange & Act
            var product = new Product();
            
            // Assert
            Assert.NotNull(product);
        }

        [Fact]
        public void Product_ShouldSetId_WhenValidValueProvided()
        {
            // Arrange
            var product = new Product();
            var expectedId = 123;

            // Act
            product.Id = expectedId;

            // Assert
            Assert.Equal(expectedId, product.Id);
        }

        [Fact]
        public void Product_ShouldSetName_WhenValidValueProvided()
        {
            // Arrange
            var product = new Product();
            var expectedName = "Test Product";

            // Act
            product.Name = expectedName;

            // Assert
            Assert.Equal(expectedName, product.Name);
        }

        [Fact]
        public void Product_ShouldSetPrice_WhenValidValueProvided()
        {
            // Arrange
            var product = new Product();
            var expectedPrice = 99.99M;

            // Act
            product.Price = expectedPrice;

            // Assert
            Assert.Equal(expectedPrice, product.Price);
        }

        [Fact]
        public void Product_ShouldHaveRequiredAttributeOnName_WhenChecked()
        {
            // Arrange
            var property = typeof(Product).GetProperty("Name");

            // Act
            var requiredAttribute = property?.GetCustomAttributes(typeof(RequiredAttribute), false);

            // Assert
            Assert.NotNull(requiredAttribute);
            Assert.True(requiredAttribute.Length > 0, "Name property should have Required attribute");
        }

        [Fact]
        public void Product_ShouldHaveRequiredAttributeOnPrice_WhenChecked()
        {
            // Arrange
            var property = typeof(Product).GetProperty("Price");

            // Act
            var requiredAttribute = property?.GetCustomAttributes(typeof(RequiredAttribute), false);

            // Assert
            Assert.NotNull(requiredAttribute);
            Assert.True(requiredAttribute.Length > 0, "Price property should have Required attribute");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(999.99)]
        [InlineData(1000000)]
        public void Product_ShouldAcceptValidPrice_WhenPositiveOrZero(decimal price)
        {
            // Arrange
            var product = new Product();

            // Act
            product.Price = price;

            // Assert
            Assert.Equal(price, product.Price);
        }

        [Fact]
        public void Product_ShouldAllowEmptyDescription_WhenSet()
        {
            // Arrange
            var product = new Product();
            var emptyDescription = "";

            // Act
            product.Description = emptyDescription;

            // Assert
            Assert.Equal(emptyDescription, product.Description);
        }

        [Fact]
        public void Product_ShouldAllowEmptyImageUrl_WhenSet()
        {
            // Arrange
            var product = new Product();
            var emptyImageUrl = "";

            // Act
            product.ImageUrl = emptyImageUrl;

            // Assert
            Assert.Equal(emptyImageUrl, product.ImageUrl);
        }

        [Fact]
        public void Product_ShouldCreateWithAllProperties_WhenInitialized()
        {
            // Arrange
            var expectedId = 1;
            var expectedName = "Test Product";
            var expectedDescription = "Test Description";
            var expectedPrice = 19.99M;
            var expectedImageUrl = "https://example.com/test.jpg";

            // Act
            var product = new Product
            {
                Id = expectedId,
                Name = expectedName,
                Description = expectedDescription,
                Price = expectedPrice,
                ImageUrl = expectedImageUrl
            };

            // Assert
            Assert.Equal(expectedId, product.Id);
            Assert.Equal(expectedName, product.Name);
            Assert.Equal(expectedDescription, product.Description);
            Assert.Equal(expectedPrice, product.Price);
            Assert.Equal(expectedImageUrl, product.ImageUrl);
        }
    }
}