using Microsoft.AspNetCore.Mvc;
using magero_store.Services;

namespace magero_store.Controllers
{
    /// <summary>
    /// Controlador principal de la aplicación (patrón MVC).
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Constructor del controlador Home.
        /// </summary>
        /// <param name="productService">Servicio de productos (inyección de dependencias).</param>
        public HomeController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        /// <summary>
        /// Muestra la página principal con una lista de productos destacados.
        /// </summary>
        /// <returns>Vista con la lista de productos.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        /// <summary>
        /// Muestra la página de error.
        /// </summary>
        /// <returns>Vista de error.</returns>
        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
    }
}