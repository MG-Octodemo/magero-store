using magero_store.Models;
using magero_store.ViewModels;

namespace magero_store.Services
{
    /// <summary>
    /// Interface del servicio del carrito de compras.
    /// Define las operaciones disponibles para gestionar el carrito según el patrón MVC.
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Obtiene el carrito actual del usuario.
        /// </summary>
        /// <returns>ViewModel del carrito con todos los items.</returns>
        CartViewModel GetCart();

        /// <summary>
        /// Agrega un producto al carrito o incrementa su cantidad si ya existe.
        /// </summary>
        /// <param name="productId">ID del producto a agregar.</param>
        /// <param name="quantity">Cantidad a agregar (por defecto 1).</param>
        /// <returns>True si se agregó exitosamente, false si el producto no existe.</returns>
        Task<bool> AddToCartAsync(int productId, int quantity = 1);

        /// <summary>
        /// Elimina un producto del carrito.
        /// </summary>
        /// <param name="productId">ID del producto a eliminar.</param>
        void RemoveFromCart(int productId);

        /// <summary>
        /// Actualiza la cantidad de un producto en el carrito.
        /// </summary>
        /// <param name="productId">ID del producto.</param>
        /// <param name="quantity">Nueva cantidad.</param>
        /// <returns>True si se actualizó exitosamente.</returns>
        bool UpdateQuantity(int productId, int quantity);

        /// <summary>
        /// Limpia todos los items del carrito.
        /// </summary>
        void ClearCart();

        /// <summary>
        /// Obtiene el número total de items en el carrito.
        /// </summary>
        /// <returns>Cantidad total de items.</returns>
        int GetCartItemCount();
    }
}
