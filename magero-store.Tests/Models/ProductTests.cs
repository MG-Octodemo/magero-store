using magero_store.Models;
using NUnit.Framework;

namespace magero_store.Tests.Models
{
    /// <summary>
    /// Pruebas unitarias para el modelo Product.
    /// </summary>
    [TestFixture]
    public class ProductTests
    {
        /// <summary>
        /// Verifica que se puede crear un producto con propiedades válidas.
        /// </summary>
        [Test]
        public void Product_CanBeCreatedWithValidProperties()
        {
            // Arrange & Act
            var product = new Product
            {
                Id = 1,
                Name = "Producto de prueba",
                Description = "Descripción de prueba",
                Price = 99.99m,
                ImageUrl = "https://example.com/image.jpg"
            };

            // Assert
            Assert.AreEqual(1, product.Id);
            Assert.AreEqual("Producto de prueba", product.Name);
            Assert.AreEqual("Descripción de prueba", product.Description);
            Assert.AreEqual(99.99m, product.Price);
            Assert.AreEqual("https://example.com/image.jpg", product.ImageUrl);
        }

        /// <summary>
        /// Verifica que el precio de un producto puede ser cero.
        /// </summary>
        [Test]
        public void Product_PriceCanBeZero()
        {
            // Arrange & Act
            var product = new Product
            {
                Id = 2,
                Name = "Producto gratis",
                Description = "Producto sin costo",
                Price = 0m,
                ImageUrl = "https://example.com/free.jpg"
            };

            // Assert
            Assert.AreEqual(0m, product.Price);
        }

        /// <summary>
        /// Verifica que el precio de un producto puede ser un valor decimal.
        /// </summary>
        [Test]
        public void Product_PriceCanBeDecimal()
        {
            // Arrange & Act
            var product = new Product
            {
                Id = 3,
                Name = "Producto con centavos",
                Description = "Producto con precio decimal",
                Price = 19.99m,
                ImageUrl = "https://example.com/decimal.jpg"
            };

            // Assert
            Assert.AreEqual(19.99m, product.Price);
        }
    }
}
