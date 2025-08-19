using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using magero_store.Controllers;
using magero_store.Data;
using magero_store.Models;
using System.Collections.Generic;

namespace magero_store_tests
{
    /// <summary>
    /// Pruebas unitarias para el controlador HomeController.
    /// Valida parámetros recibidos y conexiones al iniciar cada método.
    /// </summary>
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController? _controller;

        /// <summary>
        /// Configuración inicial para cada prueba.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _controller = new HomeController();
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
        /// Verifica que el método Index devuelve una vista con la lista de productos.
        /// </summary>
        [TestMethod]
        public void Index_DebeRetornarVistaConProductos()
        {
            // Arrange
            Assert.IsNotNull(_controller, "El controlador debe estar inicializado");

            // Act
            var resultado = _controller.Index();

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.IsInstanceOfType(resultado, typeof(ViewResult), "El resultado debe ser una ViewResult");
            
            var viewResult = resultado as ViewResult;
            Assert.IsNotNull(viewResult?.Model, "El modelo de la vista no debe ser nulo");
            Assert.IsInstanceOfType(viewResult.Model, typeof(List<Product>), "El modelo debe ser una lista de productos");
            
            var productos = viewResult.Model as List<Product>;
            Assert.IsTrue(productos?.Count > 0, "La lista de productos debe contener elementos");
            Assert.AreEqual(SampleData.Products.Count, productos?.Count, "La cantidad de productos debe coincidir con SampleData");
        }

        /// <summary>
        /// Verifica que el método Error devuelve una vista de error.
        /// </summary>
        [TestMethod]
        public void Error_DebeRetornarVistaDeError()
        {
            // Arrange
            Assert.IsNotNull(_controller, "El controlador debe estar inicializado");

            // Act
            var resultado = _controller.Error();

            // Assert
            Assert.IsNotNull(resultado, "El resultado no debe ser nulo");
            Assert.IsInstanceOfType(resultado, typeof(ViewResult), "El resultado debe ser una ViewResult");
        }
    }
}