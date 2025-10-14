using System.ComponentModel.DataAnnotations;

namespace magero_store.Models
{
    /// <summary>
    /// Representa un elemento en el carrito de compras.
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Identificador único del elemento del carrito.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del producto asociado.
        /// </summary>
        [Required(ErrorMessage = "El ID del producto es obligatorio")]
        public int ProductId { get; set; }

        /// <summary>
        /// Producto asociado al elemento del carrito.
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Cantidad del producto en el carrito.
        /// </summary>
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, 100, ErrorMessage = "La cantidad debe estar entre 1 y 100")]
        public int Quantity { get; set; }
    }
}