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
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del producto.
        /// </summary>
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string? Description { get; set; }

        /// <summary>
        /// Precio del producto.
        /// </summary>
        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe estar entre 0.01 y 999,999.99")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        /// <summary>
        /// URL de la imagen del producto.
        /// </summary>
        [Url(ErrorMessage = "La URL de la imagen no es válida")]
        public string? ImageUrl { get; set; }

    }
}