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
        /// Identificador del producto.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Producto asociado al elemento del carrito.
        /// </summary>
        public required Product Product { get; set; }

        /// <summary>
        /// Cantidad del producto en el carrito.
        /// </summary>
        public int Quantity { get; set; }
    }
}