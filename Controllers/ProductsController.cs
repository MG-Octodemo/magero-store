using Microsoft.AspNetCore.Mvc;
using magero_store.Models;
using magero_store.Services;
using System.Linq;

namespace magero_store.Controllers
{
    /// <summary>
    /// Controlador de productos (patrón MVC).
    /// Gestiona las vistas y acciones relacionadas con productos delegando la lógica de negocio al servicio.
    /// </summary>
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Constructor del controlador de productos.
        /// </summary>
        /// <param name="productService">Servicio de productos (inyección de dependencias).</param>
        public ProductsController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        /// <summary>
        /// Muestra la lista de todos los productos.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda opcional.</param>
        /// <returns>Vista con lista de productos.</returns>
        [HttpGet]
        public async Task<IActionResult> Index(string? searchTerm)
        {
            IEnumerable<Product> products;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Obtener todos los productos
                products = await _productService.GetAllProductsAsync();
            }
            else
            {
                // Buscar productos por término
                products = await _productService.SearchProductsAsync(searchTerm);
                ViewBag.SearchTerm = searchTerm;
            }

            return View(products);
        }

        /// <summary>
        /// Muestra los detalles de un producto específico.
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <returns>Vista de detalles del producto.</returns>
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de producto inválido");
            }

            var product = await _productService.GetProductByIdAsync(id);
            
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Busca productos por término de búsqueda.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda.</param>
        /// <returns>Vista con resultados de búsqueda.</returns>
        [HttpGet]
        public IActionResult Search(string? searchTerm)
        {
            // Redirigir a Index con el término de búsqueda
            return RedirectToAction("Index", new { searchTerm });
        }
    }
}