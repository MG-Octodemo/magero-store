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
        [Required(ErrorMessage = "El ID del producto es requerido")]
        public int ProductId { get; set; }

        /// <summary>
        /// Producto asociado al elemento del carrito.
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Cantidad de unidades del producto.
        /// </summary>
        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, 999, ErrorMessage = "La cantidad debe estar entre 1 y 999")]
        public int Quantity { get; set; }
    }
}