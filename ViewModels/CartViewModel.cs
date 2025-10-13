using System.ComponentModel.DataAnnotations;

namespace magero_store.ViewModels
{
    /// <summary>
    /// ViewModel para la vista del carrito de compras.
    /// Separa la lógica de presentación del modelo de dominio.
    /// </summary>
    public class CartViewModel
    {
        /// <summary>
        /// Lista de items en el carrito.
        /// </summary>
        public List<CartItemViewModel> Items { get; set; } = new();

        /// <summary>
        /// Total del carrito.
        /// </summary>
        public decimal Total => Items.Sum(i => i.Subtotal);

        /// <summary>
        /// Cantidad total de items en el carrito.
        /// </summary>
        public int ItemCount => Items.Sum(i => i.Quantity);
    }

    /// <summary>
    /// ViewModel para un item individual del carrito.
    /// </summary>
    public class CartItemViewModel
    {
        /// <summary>
        /// ID del producto.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del producto.
        /// </summary>
        public string ProductDescription { get; set; } = string.Empty;

        /// <summary>
        /// Precio unitario del producto.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// URL de la imagen del producto.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Cantidad de unidades.
        /// </summary>
        [Range(1, 999, ErrorMessage = "La cantidad debe estar entre 1 y 999")]
        public int Quantity { get; set; }

        /// <summary>
        /// Subtotal del item (Cantidad * Precio).
        /// </summary>
        public decimal Subtotal => Quantity * UnitPrice;
    }
}
