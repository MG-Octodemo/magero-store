using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using magero_store.Controllers;
using magero_store.Models;
using magero_store.Data;
using System.Collections.Generic;
using System.Linq;

namespace magero_store.Tests.Controllers
{
    /// <summary>
    /// Tests para CartController siguiendo principios TDD red phase.
    /// </summary>
    public class CartControllerTests
    {
        private readonly CartController _controller;
        private readonly ApplicationDbContext _context;
        private readonly Mock<ISession> _mockSession;

        public CartControllerTests()
        {
            // Setup in-memory database for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;
            
            _context = new ApplicationDbContext(options);
            _controller = new CartController(_context);

            // Setup mock session
            _mockSession = new Mock<ISession>();
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(c => c.Session).Returns(_mockSession.Object);
            
            var mockControllerContext = new Mock<ControllerContext>();
            mockControllerContext.Object.HttpContext = mockHttpContext.Object;
            _controller.ControllerContext = mockControllerContext.Object;
        }

        [Fact]
        public void Index_ShouldReturnViewResult_WhenCalled()
        {
            // Arrange
            SetupMockSessionForEmptyCart();

            // Act
            var result = _controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ShouldReturnEmptyCartItems_WhenCartIsEmpty()
        {
            // Arrange
            SetupMockSessionForEmptyCart();

            // Act
            var result = _controller.Index() as ViewResult;
            var model = result?.Model as List<CartItem>;

            // Assert
            Assert.NotNull(model);
            Assert.Empty(model);
        }

        [Fact]
        public void AddToCart_ShouldReturnNotFoundResult_WhenProductDoesNotExist()
        {
            // Arrange
            var nonExistentProductId = 99999;

            // Act
            var result = _controller.AddToCart(nonExistentProductId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void AddToCart_ShouldReturnRedirectToActionResult_WhenProductExists()
        {
            // Arrange
            var product = CreateTestProduct();
            _context.Products.Add(product);
            _context.SaveChanges();
            SetupMockSessionForEmptyCart();

            // Act
            var result = _controller.AddToCart(product.Id);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.Equal("Index", redirectResult?.ActionName);
        }

        [Fact]
        public void AddToCart_ShouldHandleNegativeProductId_WhenCalled()
        {
            // Arrange
            var negativeProductId = -1;

            // Act
            var result = _controller.AddToCart(negativeProductId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void AddToCart_ShouldHandleZeroProductId_WhenCalled()
        {
            // Arrange
            var zeroProductId = 0;

            // Act
            var result = _controller.AddToCart(zeroProductId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void RemoveFromCart_ShouldReturnRedirectToActionResult_WhenCalled()
        {
            // Arrange
            var productId = 1;
            SetupMockSessionForEmptyCart();

            // Act
            var result = _controller.RemoveFromCart(productId);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.Equal("Index", redirectResult?.ActionName);
        }

        [Fact]
        public void RemoveFromCart_ShouldHandleNonExistentProduct_WhenCalled()
        {
            // Arrange
            var nonExistentProductId = 99999;
            SetupMockSessionForEmptyCart();

            // Act
            var result = _controller.RemoveFromCart(nonExistentProductId);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void RemoveFromCart_ShouldHandleNegativeProductId_WhenCalled()
        {
            // Arrange
            var negativeProductId = -1;
            SetupMockSessionForEmptyCart();

            // Act
            var result = _controller.RemoveFromCart(negativeProductId);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Checkout_ShouldReturnViewResult_WhenCartHasItems()
        {
            // Arrange
            var cartItems = new List<CartItem>
            {
                new CartItem { Id = 1, ProductId = 1, Quantity = 1, Product = CreateTestProduct() }
            };
            SetupMockSessionForCartWithItems(cartItems);

            // Act
            var result = _controller.Checkout();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Checkout_ShouldRedirectToHome_WhenCartIsEmpty()
        {
            // Arrange
            SetupMockSessionForEmptyCart();

            // Act
            var result = _controller.Checkout();

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.Equal("Index", redirectResult?.ActionName);
            Assert.Equal("Home", redirectResult?.ControllerName);
        }

        [Fact]
        public void Checkout_ShouldReturnCartItems_WhenCartHasItems()
        {
            // Arrange
            var testProduct = CreateTestProduct();
            var cartItems = new List<CartItem>
            {
                new CartItem { Id = 1, ProductId = 1, Quantity = 2, Product = testProduct }
            };
            SetupMockSessionForCartWithItems(cartItems);

            // Act
            var result = _controller.Checkout() as ViewResult;
            var model = result?.Model as List<CartItem>;

            // Assert
            Assert.NotNull(model);
            Assert.Single(model);
            Assert.Equal(2, model.First().Quantity);
        }

        [Fact]
        public void CartController_ShouldInheritFromController_WhenChecked()
        {
            // Arrange & Act
            var controller = new CartController(_context);

            // Assert
            Assert.IsAssignableFrom<Controller>(controller);
        }

        [Fact]
        public void CartController_ShouldRequireDbContext_WhenInstantiated()
        {
            // Arrange
            ApplicationDbContext? nullContext = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CartController(nullContext!));
        }

        [Theory]
        [InlineData(-999)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(99999)]
        [InlineData(int.MaxValue)]
        public void AddToCart_ShouldReturnNotFound_WhenInvalidProductIdProvided(int invalidProductId)
        {
            // Arrange & Act
            var result = _controller.AddToCart(invalidProductId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(-999)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(99999)]
        public void RemoveFromCart_ShouldReturnRedirect_WhenAnyProductIdProvided(int productId)
        {
            // Arrange
            SetupMockSessionForEmptyCart();

            // Act
            var result = _controller.RemoveFromCart(productId);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        private Product CreateTestProduct()
        {
            return new Product
            {
                Id = 1,
                Name = "Test Product",
                Description = "Test Description",
                Price = 19.99M,
                ImageUrl = "test.jpg"
            };
        }

        private void SetupMockSessionForEmptyCart()
        {
            _mockSession.Setup(s => s.GetString("Cart")).Returns((string?)null);
        }

        private void SetupMockSessionForCartWithItems(List<CartItem> cartItems)
        {
            var serializedCart = System.Text.Json.JsonSerializer.Serialize(cartItems);
            _mockSession.Setup(s => s.GetString("Cart")).Returns(serializedCart);
        }
    }
}