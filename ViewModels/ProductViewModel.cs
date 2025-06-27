using System.ComponentModel.DataAnnotations;
using magero_store.Helpers;

namespace magero_store.ViewModels
{
    /// <summary>
    /// ViewModel para la gestión de productos en las vistas.
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// Identificador único del producto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres.")]
        public required string Name { get; set; }

        /// <summary>
        /// Descripción del producto.
        /// </summary>
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres.")]
        public required string Description { get; set; }

        /// <summary>
        /// Precio del producto.
        /// </summary>
        [Required(ErrorMessage = "El precio es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Price { get; set; }

        /// <summary>
        /// URL de la imagen del producto.
        /// </summary>
        [Required(ErrorMessage = "La URL de la imagen es requerida.")]
        [Url(ErrorMessage = "Debe ser una URL válida.")]
        public required string ImageUrl { get; set; }

        /// <summary>
        /// Color del producto.
        /// </summary>
        [Required(ErrorMessage = "El color es requerido.")]
        [ValidColor]
        public required string Color { get; set; }
    }
}
