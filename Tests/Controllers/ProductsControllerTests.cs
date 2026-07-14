using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using magero_store.Controllers;
using magero_store.Models;
using magero_store.Data;
using Xunit;

namespace magero_store.Tests.Controllers
{
    /// <summary>
    /// Pruebas unitarias para el controlador ProductsController.
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

        /// <summary>
        /// Verifica que Index sin término de búsqueda devuelva todos los productos.
        /// </summary>
        [Fact]
        public void Index_SinTerminoDeBusqueda_DevuelveTodosLosProductos()
        {
            // Arrange
            string searchTerm = null;

            // Act
            var result = _controller.Index(searchTerm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Product>>(viewResult.Model);
            Assert.Equal(SampleData.Products.Count, model.Count);
        }

        /// <summary>
        /// Verifica que Index con término de búsqueda vacío devuelva todos los productos.
        /// </summary>
        [Fact]
        public void Index_ConTerminoVacio_DevuelveTodosLosProductos()
        {
            // Arrange
            string searchTerm = "";

            // Act
            var result = _controller.Index(searchTerm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Product>>(viewResult.Model);
            Assert.Equal(SampleData.Products.Count, model.Count);
        }

        /// <summary>
        /// Verifica que Index filtre productos por descripción.
        /// </summary>
        [Fact]
        public void Index_ConTerminoDeBusqueda_FiltraProductosPorDescripcion()
        {
            // Arrange
            string searchTerm = "laptop";

            // Act
            var result = _controller.Index(searchTerm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Product>>(viewResult.Model);
            Assert.All(model, p => Assert.Contains(searchTerm, p.Descripcion, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Verifica que Index sea case-insensitive al buscar.
        /// </summary>
        [Theory]
        [InlineData("LAPTOP")]
        [InlineData("laptop")]
        [InlineData("LaPtOp")]
        public void Index_BusquedaCaseInsensitive_DevuelveResultados(string searchTerm)
        {
            // Act
            var result = _controller.Index(searchTerm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Product>>(viewResult.Model);
            Assert.NotEmpty(model);
        }

        /// <summary>
        /// Verifica que Index devuelva lista vacía si no hay coincidencias.
        /// </summary>
        [Fact]
        public void Index_SinCoincidencias_DevuelveListaVacia()
        {
            // Arrange
            string searchTerm = "productonexistente12345";

            // Act
            var result = _controller.Index(searchTerm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Product>>(viewResult.Model);
            Assert.Empty(model);
        }

        /// <summary>
        /// Verifica que Details devuelva el producto correcto por ID.
        /// </summary>
        [Fact]
        public void Details_ConIdValido_DevuelveProductoCorrecto()
        {
            // Arrange
            int productId = 1;

            // Act
            var result = _controller.Details(productId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Product>(viewResult.Model);
            Assert.Equal(productId, model.Id);
        }

        /// <summary>
        /// Verifica que Details devuelva NotFound para ID inexistente.
        /// </summary>
        [Fact]
        public void Details_ConIdInexistente_DevuelveNotFound()
        {
            // Arrange
            int productId = 99999;

            // Act
            var result = _controller.Details(productId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        /// <summary>
        /// Verifica que Details con diferentes IDs válidos devuelva productos diferentes.
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Details_ConDiferentesIds_DevuelveProductosCorrectos(int productId)
        {
            // Act
            var result = _controller.Details(productId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Product>(viewResult.Model);
            Assert.Equal(productId, model.Id);
        }

        /// <summary>
        /// Verifica que Search con término vacío devuelva lista vacía.
        /// </summary>
        [Fact]
        public void Search_ConTerminoVacio_DevuelveListaVacia()
        {
            // Arrange
            string searchTerm = "";

            // Act
            var result = _controller.Search(searchTerm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
            var model = Assert.IsAssignableFrom<List<Product>>(viewResult.Model);
            Assert.Empty(model);
        }

        /// <summary>
        /// Verifica que Search con término null devuelva lista vacía.
        /// </summary>
        [Fact]
        public void Search_ConTerminoNull_DevuelveListaVacia()
        {
            // Arrange
            string searchTerm = null;

            // Act
            var result = _controller.Search(searchTerm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
            var model = Assert.IsAssignableFrom<List<Product>>(viewResult.Model);
            Assert.Empty(model);
        }

        /// <summary>
        /// Verifica que Search con término demasiado largo devuelva BadRequest.
        /// </summary>
        [Fact]
        public void Search_ConTerminoDemasiadoLargo_DevuelveBadRequest()
        {
            // Arrange
            string searchTerm = new string('a', 101); // 101 caracteres

            // Act
            var result = _controller.Search(searchTerm);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        /// <summary>
        /// Verifica que el controlador se inicialice correctamente con configuración.
        /// </summary>
        [Fact]
        public void Constructor_ConConfiguracionValida_CreaInstancia()
        {
            // Arrange & Act
            var controller = new ProductsController(_mockConfiguration.Object);

            // Assert
            Assert.NotNull(controller);
        }

        /// <summary>
        /// Verifica que Search valide parámetros antes de ejecutar la consulta.
        /// </summary>
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t")]
        [InlineData("\n")]
        public void Search_ConEspaciosEnBlanco_DevuelveListaVacia(string searchTerm)
        {
            // Act
            var result = _controller.Search(searchTerm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
            var model = Assert.IsAssignableFrom<List<Product>>(viewResult.Model);
            Assert.Empty(model);
        }
    }
}
