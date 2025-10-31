using System.Collections.Generic;
using magero_store.Controllers;
using magero_store.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace magero_store.Tests.Controllers
{
    /// <summary>
    /// Pruebas unitarias para el controlador HomeController.
    /// </summary>
    [TestFixture]
    public class HomeControllerTests
    {
        /// <summary>
        /// Verifica que el método Index retorna una vista.
        /// </summary>
        [Test]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        /// <summary>
        /// Verifica que el método Index retorna una vista con un modelo de tipo lista de productos.
        /// </summary>
        [Test]
        public void Index_ReturnsViewResultWithProductList()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOf<List<Product>>(result.Model);
        }

        /// <summary>
        /// Verifica que el método Error retorna una vista.
        /// </summary>
        [Test]
        public void Error_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Error();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
