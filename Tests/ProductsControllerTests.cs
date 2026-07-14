using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using magero_store.Controllers;
using magero_store.Data;
using magero_store.Models;
using System.Collections.Generic;
using System.Linq;

namespace magero_store_tests
{
    /// <summary>
    /// Pruebas unitarias para el controlador ProductsController.
    /// Valida parámetros recibidos y conexiones al iniciar cada método.
    /// </summary>
    [TestClass]
    public class ProductsControllerTests
    {
        private ProductsController? _controller;
        private IConfiguration? _configuration;

        /// <summary>
        /// Configuración inicial para cada prueba.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // Crear configuración básica para testing
            var inMemorySettings = new Dictionary<string, string>
            {
                {"ConnectionStrings:DefaultConnection", "Data Source=:memory:"}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings!)
                .Build();
            
            _controller = new ProductsController(_configuration);
        }

        /// <summary>
        /// Limpieza después de cada prueba.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            _controller?.Dispose();
        }

        /// <summary>
        /// Verifica que Index sin término de búsqueda devuelve todos los productos.
        /// </summary>
        [TestMethod]
        public void Index_SinTerminoBusqueda_DebeRetornarTodosLosProductos()
        {
            // Arrange
            Assert.IsNotNull(_controller, "El controlador debe estar inicializado");

            // Act
            var resultado = _controller.Index(null);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.IsInstanceOfType(resultado, typeof(ViewResult), "El resultado debe ser una ViewResult");
            
            var viewResult = resultado as ViewResult;
            Assert.IsNotNull(viewResult?.Model, "El modelo de la vista no debe ser nulo");
            Assert.IsInstanceOfType(viewResult.Model, typeof(List<Product>), "El modelo debe ser una lista de productos");
            
            var productos = viewResult.Model as List<Product>;
            Assert.AreEqual(SampleData.Products.Count, productos?.Count, "Debe devolver todos los productos de SampleData");
        }

        /// <summary>
        /// Verifica que Index con término de búsqueda vacío devuelve todos los productos.
        /// </summary>
        [TestMethod]
        public void Index_ConTerminoVacio_DebeRetornarTodosLosProductos()
        {
            // Arrange
            Assert.IsNotNull(_controller, "El controlador debe estar inicializado");

            // Act
            var resultado = _controller.Index("");

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.IsInstanceOfType(resultado, typeof(ViewResult), "El resultado debe ser una ViewResult");
            
            var viewResult = resultado as ViewResult;
            var productos = viewResult?.Model as List<Product>;
            Assert.AreEqual(SampleData.Products.Count, productos?.Count, "Debe devolver todos los productos cuando el término está vacío");
        }

        /// <summary>
        /// Verifica que Index con término de búsqueda válido filtra los productos correctamente.
        /// </summary>
        [TestMethod]
        public void Index_ConTerminoBusqueda_DebeRetornarProductosFiltrados()
        {
            // Arrange
            Assert.IsNotNull(_controller, "El controlador debe estar inicializado");
            string terminoBusqueda = "laptop";

            // Act
            var resultado = _controller.Index(terminoBusqueda);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.IsInstanceOfType(resultado, typeof(ViewResult), "El resultado debe ser una ViewResult");
            
            var viewResult = resultado as ViewResult;
            var productos = viewResult?.Model as List<Product>;
            
            // Verificar que todos los productos contienen el término de búsqueda en la descripción
            Assert.IsTrue(productos?.All(p => p.Description.Contains(terminoBusqueda, System.StringComparison.OrdinalIgnoreCase)) == true, 
                         "Todos los productos filtrados deben contener el término de búsqueda");
        }

        /// <summary>
        /// Verifica que Details con ID válido devuelve el producto correcto.
        /// </summary>
        [TestMethod]
        public void Details_ConIdValido_DebeRetornarProducto()
        {
            // Arrange
            Assert.IsNotNull(_controller, "El controlador debe estar inicializado");
            int idProducto = 1;

            // Act
            var resultado = _controller.Details(idProducto);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.IsInstanceOfType(resultado, typeof(ViewResult), "El resultado debe ser una ViewResult");
            
            var viewResult = resultado as ViewResult;
            Assert.IsNotNull(viewResult?.Model, "El modelo de la vista no debe ser nulo");
            Assert.IsInstanceOfType(viewResult.Model, typeof(Product), "El modelo debe ser un Product");
            
            var producto = viewResult.Model as Product;
            Assert.AreEqual(idProducto, producto?.Id, "El ID del producto debe coincidir");
        }

        /// <summary>
        /// Verifica que Details con ID inválido devuelve NotFound.
        /// </summary>
        [TestMethod]
        public void Details_ConIdInvalido_DebeRetornarNotFound()
        {
            // Arrange
            Assert.IsNotNull(_controller, "El controlador debe estar inicializado");
            int idInvalido = 999;

            // Act
            var resultado = _controller.Details(idInvalido);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.IsInstanceOfType(resultado, typeof(NotFoundResult), "El resultado debe ser NotFoundResult");
        }

        /// <summary>
        /// Verifica que la configuración está correctamente inicializada.
        /// </summary>
        [TestMethod]
        public void Configuration_DebeEstarInicializadaCorrectamente()
        {
            // Arrange & Assert
            Assert.IsNotNull(_controller, "El controlador debe estar inicializado");
            Assert.IsNotNull(_configuration, "La configuración debe estar inicializada");
            
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            Assert.IsNotNull(connectionString, "La cadena de conexión debe estar configurada");
            Assert.AreEqual("Data Source=:memory:", connectionString, "La cadena de conexión debe ser la esperada");
        }
    }
}