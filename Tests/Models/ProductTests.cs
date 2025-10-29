using System.ComponentModel.DataAnnotations;
using magero_store.Models;
using Xunit;

namespace magero_store.Tests.Models
{
    /// <summary>
    /// Pruebas unitarias para el modelo Product.
    /// </summary>
    public class ProductTests
    {
        /// <summary>
        /// Verifica que un producto válido no genere errores de validación.
        /// </summary>
        [Fact]
        public void Product_ConDatosValidos_NoGeneraErroresDeValidacion()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Nombre = "Laptop",
                Descripcion = "Una laptop de alto rendimiento",
                Precio = 999.99M,
                ImagenUrl = "https://ejemplo.com/imagen.jpg"
            };

            // Act
            var validationResults = ValidateModel(product);

            // Assert
            Assert.Empty(validationResults);
        }

        /// <summary>
        /// Verifica que un producto sin nombre genere error de validación.
        /// </summary>
        [Fact]
        public void Product_SinNombre_GeneraErrorDeValidacion()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Nombre = null,
                Descripcion = "Una descripción",
                Precio = 99.99M,
                ImagenUrl = "https://ejemplo.com/imagen.jpg"
            };

            // Act
            var validationResults = ValidateModel(product);

            // Assert
            Assert.NotEmpty(validationResults);
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Nombre"));
        }

        /// <summary>
        /// Verifica que un producto con nombre vacío genere error de validación.
        /// </summary>
        [Fact]
        public void Product_ConNombreVacio_GeneraErrorDeValidacion()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Nombre = "",
                Descripcion = "Una descripción",
                Precio = 99.99M,
                ImagenUrl = "https://ejemplo.com/imagen.jpg"
            };

            // Act
            var validationResults = ValidateModel(product);

            // Assert
            Assert.NotEmpty(validationResults);
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Nombre"));
        }

        /// <summary>
        /// Verifica que las propiedades del producto se asignen correctamente.
        /// </summary>
        [Fact]
        public void Product_PropiedadesSeAsignanCorrectamente()
        {
            // Arrange & Act
            var product = new Product
            {
                Id = 10,
                Nombre = "Smartphone",
                Descripcion = "Un smartphone moderno",
                Precio = 599.99M,
                ImagenUrl = "https://ejemplo.com/smartphone.jpg"
            };

            // Assert
            Assert.Equal(10, product.Id);
            Assert.Equal("Smartphone", product.Nombre);
            Assert.Equal("Un smartphone moderno", product.Descripcion);
            Assert.Equal(599.99M, product.Precio);
            Assert.Equal("https://ejemplo.com/smartphone.jpg", product.ImagenUrl);
        }

        /// <summary>
        /// Verifica que el precio se maneje correctamente con decimales.
        /// </summary>
        [Theory]
        [InlineData(0.01)]
        [InlineData(10.50)]
        [InlineData(999.99)]
        [InlineData(1000.00)]
        public void Product_PrecioConDecimales_SeAlmacenaCorrectamente(decimal precio)
        {
            // Arrange & Act
            var product = new Product
            {
                Id = 1,
                Nombre = "Producto de prueba",
                Descripcion = "Descripción",
                Precio = precio,
                ImagenUrl = "https://ejemplo.com/imagen.jpg"
            };

            // Assert
            Assert.Equal(precio, product.Precio);
        }

        /// <summary>
        /// Verifica que un producto pueda tener descripción nula.
        /// </summary>
        [Fact]
        public void Product_ConDescripcionNula_EsValido()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Nombre = "Producto",
                Descripcion = null,
                Precio = 99.99M,
                ImagenUrl = "https://ejemplo.com/imagen.jpg"
            };

            // Act
            var validationResults = ValidateModel(product);

            // Assert
            Assert.Empty(validationResults);
            Assert.Null(product.Descripcion);
        }

        /// <summary>
        /// Verifica que un producto pueda tener ImagenUrl nula.
        /// </summary>
        [Fact]
        public void Product_ConImagenUrlNula_EsValido()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Nombre = "Producto",
                Descripcion = "Descripción",
                Precio = 99.99M,
                ImagenUrl = null
            };

            // Act
            var validationResults = ValidateModel(product);

            // Assert
            Assert.Empty(validationResults);
            Assert.Null(product.ImagenUrl);
        }

        /// <summary>
        /// Método helper para validar el modelo.
        /// </summary>
        private List<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
