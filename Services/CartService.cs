using magero_store.Data;
using magero_store.Models;
using magero_store.ViewModels;
using magero_store.Helpers;
using Microsoft.EntityFrameworkCore;

namespace magero_store.Services
{
    /// <summary>
    /// Implementación del servicio del carrito de compras.
    /// Gestiona la lógica de negocio del carrito separada del controlador (patrón MVC).
    /// </summary>
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor del servicio de carrito.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        /// <param name="httpContextAccessor">Accessor para acceder al contexto HTTP y la sesión.</param>
        public CartService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// Obtiene el carrito actual del usuario desde la sesión.
        /// </summary>
        /// <returns>ViewModel del carrito.</returns>
        public CartViewModel GetCart()
        {
            var cartItems = GetCartItemsFromSession();
            
            var viewModel = new CartViewModel
            {
                Items = cartItems.Select(ci => new CartItemViewModel
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product?.Name ?? string.Empty,
                    ProductDescription = ci.Product?.Description ?? string.Empty,
                    UnitPrice = ci.Product?.Price ?? 0,
                    ImageUrl = ci.Product?.ImageUrl ?? string.Empty,
                    Quantity = ci.Quantity
                }).ToList()
            };

            return viewModel;
        }

        /// <summary>
        /// Agrega un producto al carrito.
        /// </summary>
        /// <param name="productId">ID del producto.</param>
        /// <param name="quantity">Cantidad a agregar.</param>
        /// <returns>True si se agregó exitosamente.</returns>
        public async Task<bool> AddToCartAsync(int productId, int quantity = 1)
        {
            // Validación de parámetros
            if (productId <= 0 || quantity <= 0)
            {
                return false;
            }

            // Buscar producto en la base de datos
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return false;
            }

            // Obtener carrito actual
            var cartItems = GetCartItemsFromSession();
            var existingItem = cartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (existingItem != null)
            {
                // Incrementar cantidad si ya existe
                existingItem.Quantity += quantity;
            }
            else
            {
                // Agregar nuevo item
                cartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Product = product,
                    Quantity = quantity
                });
            }

            // Guardar en sesión
            SaveCartItemsToSession(cartItems);
            return true;
        }

        /// <summary>
        /// Elimina un producto del carrito.
        /// </summary>
        /// <param name="productId">ID del producto a eliminar.</param>
        public void RemoveFromCart(int productId)
        {
            if (productId <= 0) return;

            var cartItems = GetCartItemsFromSession();
            var itemToRemove = cartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                SaveCartItemsToSession(cartItems);
            }
        }

        /// <summary>
        /// Actualiza la cantidad de un producto en el carrito.
        /// </summary>
        /// <param name="productId">ID del producto.</param>
        /// <param name="quantity">Nueva cantidad.</param>
        /// <returns>True si se actualizó exitosamente.</returns>
        public bool UpdateQuantity(int productId, int quantity)
        {
            if (productId <= 0 || quantity <= 0) return false;

            var cartItems = GetCartItemsFromSession();
            var item = cartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (item != null)
            {
                item.Quantity = quantity;
                SaveCartItemsToSession(cartItems);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Limpia todos los items del carrito.
        /// </summary>
        public void ClearCart()
        {
            SaveCartItemsToSession(new List<CartItem>());
        }

        /// <summary>
        /// Obtiene el número total de items en el carrito.
        /// </summary>
        /// <returns>Cantidad total de items.</returns>
        public int GetCartItemCount()
        {
            var cartItems = GetCartItemsFromSession();
            return cartItems.Sum(ci => ci.Quantity);
        }

        #region Métodos Privados de Sesión

        /// <summary>
        /// Obtiene los items del carrito desde la sesión.
        /// </summary>
        /// <returns>Lista de items del carrito.</returns>
        private List<CartItem> GetCartItemsFromSession()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null) return new List<CartItem>();

            return httpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
        }

        /// <summary>
        /// Guarda los items del carrito en la sesión.
        /// </summary>
        /// <param name="cartItems">Lista de items a guardar.</param>
        private void SaveCartItemsToSession(List<CartItem> cartItems)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                httpContext.Session.Set("Cart", cartItems);
            }
        }

        #endregion
    }
}
