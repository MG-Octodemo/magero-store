using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using magero_store.Controllers;
using magero_store.Data;
using magero_store.Models;
using System.Linq;

namespace magero_store_tests
{
    /// <summary>
    /// Pruebas unitarias para el controlador CartController.
    /// Valida parámetros recibidos y conexiones al iniciar cada método.
    /// </summary>
    [TestClass]
    public class CartControllerTests
    {
        private CartController? _controller;
        private magero_store.Data.ApplicationDbContext? _context;

        /// <summary>
        /// Configuración inicial para cada prueba.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // Validar parámetros recibidos y conexiones al iniciar
            var options = new DbContextOptionsBuilder<magero_store.Data.ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;

            _context = new magero_store.Data.ApplicationDbContext(options);
            
            // Agregar datos de prueba
            SeedTestData();

            _controller = new CartController(_context);
        }

        /// <summary>
        /// Limpieza después de cada prueba.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            _controller?.Dispose();
            _context?.Dispose();
        }

        /// <summary>
        /// Agrega datos de prueba al contexto de base de datos.
        /// </summary>
        private void SeedTestData()
        {
            if (_context == null) return;

            var productos = new[]
            {
                new Product { Id = 1, Name = "Producto 1", Description = "Descripción 1", Price = 100, ImageUrl = "url1" },
                new Product { Id = 2, Name = "Producto 2", Description = "Descripción 2", Price = 200, ImageUrl = "url2" }
            };

            _context.Products.AddRange(productos);
            _context.SaveChanges();
        }

        /// <summary>
        /// Verifica que el controlador se inicializa correctamente con dependencias.
        /// </summary>
        [TestMethod]
        public void Constructor_ConContextoValido_DebeInicializarCorrectamente()
        {
            // Arrange & Act - ya realizado en Setup

            // Assert
            Assert.IsNotNull(_controller, "El controlador debe estar inicializado");
            Assert.IsNotNull(_context, "El contexto debe estar inicializado");
            Assert.IsTrue(_context.Products.Any(), "Debe haber productos de prueba en el contexto");
        }

        /// <summary>
        /// Verifica que AddToCart con producto inválido devuelve NotFound.
        /// </summary>
        [TestMethod]
        public void AddToCart_ConProductoInvalido_DebeRetornarNotFound()
        {
            // Arrange
            Assert.IsNotNull(_controller, "El controlador debe estar inicializado");
            int productIdInvalido = 999;

            // Act
            var resultado = _controller.AddToCart(productIdInvalido);

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.IsInstanceOfType(resultado, typeof(NotFoundResult), "El resultado debe ser NotFoundResult");
        }

        /// <summary>
        /// Verifica que el contexto tiene los datos de prueba correctos.
        /// </summary>
        [TestMethod]
        public void Context_DebeTenerDatosDePrueba()
        {
            // Arrange & Act
            Assert.IsNotNull(_context, "El contexto debe estar inicializado");

            // Assert
            var productos = _context.Products.ToList();
            Assert.AreEqual(2, productos.Count, "Debe haber exactamente 2 productos de prueba");
            Assert.IsTrue(productos.Any(p => p.Id == 1), "Debe existir el producto con ID 1");
            Assert.IsTrue(productos.Any(p => p.Id == 2), "Debe existir el producto con ID 2");
        }

        /// <summary>
        /// Verifica que el contexto Products está configurado correctamente.
        /// </summary>
        [TestMethod]
        public void Context_ProductsDbSet_DebeEstarConfigurado()
        {
            // Arrange
            Assert.IsNotNull(_context, "El contexto debe estar inicializado");

            // Act
            var producto = _context.Products.Find(1);

            // Assert
            Assert.IsNotNull(producto, "Debe encontrar el producto con ID 1");
            Assert.AreEqual("Producto 1", producto.Name, "El nombre del producto debe ser correcto");
            Assert.AreEqual(100, producto.Price, "El precio del producto debe ser correcto");
        }

        /// <summary>
        /// Verifica que el contexto puede buscar productos por ID.
        /// </summary>
        [TestMethod]
        public void Context_Find_DebeBuscarProductosPorId()
        {
            // Arrange
            Assert.IsNotNull(_context, "El contexto debe estar inicializado");

            // Act
            var productoEncontrado = _context.Products.Find(1);
            var productoNoEncontrado = _context.Products.Find(999);

            // Assert
            Assert.IsNotNull(productoEncontrado, "Debe encontrar el producto con ID 1");
            Assert.IsNull(productoNoEncontrado, "No debe encontrar producto con ID inexistente");
        }
    }
}