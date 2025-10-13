using System.ComponentModel.DataAnnotations;

namespace magero_store.Models
{
    /// <summary>
    /// Representa un producto en la tienda.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Identificador único del producto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 200 caracteres")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del producto.
        /// </summary>
        [Required(ErrorMessage = "La descripción del producto es requerida")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 1000 caracteres")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Precio del producto.
        /// </summary>
        [Required(ErrorMessage = "El precio del producto es requerido")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe estar entre 0.01 y 999999.99")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        /// <summary>
        /// URL de la imagen del producto.
        /// </summary>
        [Required(ErrorMessage = "La URL de la imagen es requerida")]
        [Url(ErrorMessage = "Debe ser una URL válida")]
        [StringLength(500, ErrorMessage = "La URL no puede exceder 500 caracteres")]
        public string ImageUrl { get; set; } = string.Empty;

    }
}