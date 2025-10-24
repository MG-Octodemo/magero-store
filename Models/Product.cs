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
        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción del producto.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Precio del producto.
        /// </summary>
        [Required]
        public decimal Precio { get; set; }

        /// <summary>
        /// URL de la imagen del producto.
        /// </summary>
        public string ImagenUrl { get; set; }

    }
}