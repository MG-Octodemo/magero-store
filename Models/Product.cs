using System.ComponentModel.DataAnnotations;
using magero_store.Helpers;

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
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Descripción del producto.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Precio del producto.
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// URL de la imagen del producto.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Color del producto.
        /// </summary>
        [Required(ErrorMessage = "El color es requerido.")]
        [ValidColor]
        public string Color { get; set; }

    }
}