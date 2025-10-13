using Microsoft.AspNetCore.Mvc;
using magero_store.Models;
using magero_store.Services;
using magero_store.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace magero_store.Controllers
{
    /// <summary>
    /// Controlador del carrito de compras (patrón MVC).
    /// Gestiona las interacciones del usuario con el carrito delegando la lógica de negocio al servicio.
    /// </summary>
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        /// <summary>
        /// Constructor del controlador de carrito.
        /// </summary>
        /// <param name="cartService">Servicio de carrito (inyección de dependencias).</param>
        public CartController(ICartService cartService)
        {
            _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
        }

        /// <summary>
        /// Muestra la página del carrito con los elementos actuales.
        /// </summary>
        /// <returns>Vista con los elementos del carrito.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var cartViewModel = _cartService.GetCart();
            return View(cartViewModel);
        }

        /// <summary>
        /// Agrega un producto al carrito.
        /// </summary>
        /// <param name="productId">ID del producto a agregar.</param>
        /// <param name="quantity">Cantidad a agregar (opcional, por defecto 1).</param>
        /// <returns>Redirige a la vista del carrito.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            // Validación del parámetro
            if (productId <= 0)
            {
                return BadRequest("ID de producto inválido");
            }

            // Delegar la lógica de negocio al servicio
            var result = await _cartService.AddToCartAsync(productId, quantity);
            
            if (!result)
            {
                return NotFound("Producto no encontrado");
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Elimina un producto del carrito.
        /// </summary>
        /// <param name="productId">ID del producto a eliminar.</param>
        /// <returns>Redirige a la vista del carrito.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromCart(int productId)
        {
            // Validación del parámetro
            if (productId <= 0)
            {
                return BadRequest("ID de producto inválido");
            }

            // Delegar la lógica de negocio al servicio
            _cartService.RemoveFromCart(productId);
            
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Muestra la página de checkout con los elementos actuales del carrito.
        /// </summary>
        /// <returns>Vista de checkout con el ViewModel.</returns>
        [HttpGet]
        public IActionResult Checkout()
        {
            var cartViewModel = _cartService.GetCart();
            
            if (!cartViewModel.Items.Any())
            {
                return RedirectToAction("Index", "Home");
            }

            // Crear CheckoutViewModel con datos del carrito
            var checkoutViewModel = new CheckoutViewModel
            {
                CartItems = cartViewModel.Items
            };

            return View(checkoutViewModel);
        }

        /// <summary>
        /// Procesa el checkout del pedido.
        /// </summary>
        /// <param name="model">ViewModel con información del checkout.</param>
        /// <returns>Resultado del procesamiento.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Recargar items del carrito si hay errores de validación
                var cartViewModel = _cartService.GetCart();
                model.CartItems = cartViewModel.Items;
                return View(model);
            }

            // TODO: Implementar lógica de procesamiento de pedido
            // Por ahora solo limpiar el carrito
            _cartService.ClearCart();

            // Redirigir a una página de confirmación
            TempData["SuccessMessage"] = "¡Pedido realizado exitosamente!";
            return RedirectToAction("Index", "Home");
        }
    }
}