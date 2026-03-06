using Microsoft.AspNetCore.Mvc;
using magero_store.Models;
using System.Collections.Generic;
using System.Linq;
using magero_store.Helpers;
using magero_store.Data;

namespace magero_store.Controllers
{
    /// <summary>
    /// Controlador para gestionar las operaciones del carrito de compras.
    /// </summary>
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor que inyecta el contexto de base de datos.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        public CartController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Muestra la página del carrito con los elementos actuales.
        /// </summary>
        /// <returns>Vista con los elementos del carrito.</returns>
        public IActionResult Index()
        {
            var cartItems = GetCartItems();
            return View(cartItems);
        }

        /// <summary>
        /// Agrega un producto al carrito.
        /// </summary>
        /// <param name="productId">ID del producto a agregar.</param>
        /// <returns>Redirige a la vista del carrito.</returns>
        public IActionResult AddToCart(int productId)
        {
            // Validar que el ID sea positivo
            if (productId <= 0)
            {
                return BadRequest("ID de producto inválido.");
            }

            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound();
            }

            var cartItems = GetCartItems();
            var cartItem = cartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem == null)
            {
                cartItems.Add(new CartItem { ProductId = productId, Quantity = 1, Product = product });
            }
            else
            {
                cartItem.Quantity++;
            }

            SaveCartItems(cartItems);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Elimina un producto del carrito.
        /// </summary>
        /// <param name="productId">ID del producto a eliminar.</param>
        /// <returns>Redirige a la vista del carrito.</returns>
        public IActionResult RemoveFromCart(int productId)
        {
            // Validar que el ID sea positivo
            if (productId <= 0)
            {
                return BadRequest("ID de producto inválido.");
            }

            var cartItems = GetCartItems();
            var cartItem = cartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem != null)
            {
                cartItems.Remove(cartItem);
            }

            SaveCartItems(cartItems);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Muestra la página de checkout con los elementos actuales del carrito.
        /// </summary>
        /// <returns>Vista de checkout.</returns>
        public IActionResult Checkout()
        {
            var cartItems = GetCartItems();
            if (!cartItems.Any())
            {
                return RedirectToAction("Index", "Home");
            }

            return View(cartItems);
        }

        /// <summary>
        /// Obtiene los elementos actuales del carrito desde la sesión.
        /// </summary>
        /// <returns>Lista de elementos del carrito.</returns>
        private List<CartItem> GetCartItems()
        {
            return HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
        }

        /// <summary>
        /// Guarda los elementos del carrito en la sesión.
        /// </summary>
        /// <param name="cartItems">Lista de elementos del carrito a guardar.</param>
        private void SaveCartItems(List<CartItem> cartItems)
        {
            HttpContext.Session.Set("Cart", cartItems);
        }
    }
}