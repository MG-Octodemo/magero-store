using Microsoft.AspNetCore.Mvc;
using magero_store.Models;
using magero_store.Data;
using magero_store.Services;
using magero_store.ViewModels;
using Microsoft.Data.SqlClient;  // Changed from System.Data.SqlClient
using Dapper;
using System.Linq;

namespace magero_store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductFilterService _filterService;

        /// <summary>
        /// Constructor del controlador de productos.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación</param>
        /// <param name="filterService">Servicio de filtrado de productos</param>
        public ProductsController(IConfiguration configuration, IProductFilterService filterService)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _filterService = filterService ?? throw new ArgumentNullException(nameof(filterService));
        }

        /// <summary>
        /// Muestra la página principal de productos con filtros opcionales.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda</param>
        /// <param name="priceRange">Rango de precios predefinido</param>
        /// <param name="minPrice">Precio mínimo personalizado</param>
        /// <param name="maxPrice">Precio máximo personalizado</param>
        /// <returns>Vista con productos filtrados</returns>
        public IActionResult Index(string searchTerm, PriceRange priceRange = PriceRange.All, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var products = SampleData.Products.AsEnumerable();

            // Aplicar filtro de búsqueda
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                              p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            // Aplicar filtro de precio
            if (priceRange == PriceRange.Custom)
            {
                products = _filterService.FilterByCustomPriceRange(products, minPrice, maxPrice);
            }
            else
            {
                products = _filterService.FilterByPriceRange(products, priceRange);
            }

            var viewModel = new ProductsIndexViewModel
            {
                Products = products.ToList(),
                SelectedPriceRange = priceRange,
                CustomMinPrice = minPrice,
                CustomMaxPrice = maxPrice,
                SearchTerm = searchTerm,
                TotalProducts = products.Count()
            };

            return View(viewModel);
        }

        /// <summary>
        /// Acción AJAX para filtrar productos sin recargar la página.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda</param>
        /// <param name="priceRange">Rango de precios predefinido</param>
        /// <param name="minPrice">Precio mínimo personalizado</param>
        /// <param name="maxPrice">Precio máximo personalizado</param>
        /// <returns>Vista parcial con los productos filtrados</returns>
        [HttpPost]
        public IActionResult FilterProducts(string searchTerm, PriceRange priceRange = PriceRange.All, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var products = SampleData.Products.AsEnumerable();

            // Aplicar filtro de búsqueda
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                              p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            // Aplicar filtro de precio
            if (priceRange == PriceRange.Custom)
            {
                products = _filterService.FilterByCustomPriceRange(products, minPrice, maxPrice);
            }
            else
            {
                products = _filterService.FilterByPriceRange(products, priceRange);
            }

            var viewModel = new ProductsIndexViewModel
            {
                Products = products.ToList(),
                SelectedPriceRange = priceRange,
                CustomMinPrice = minPrice,
                CustomMaxPrice = maxPrice,
                SearchTerm = searchTerm,
                TotalProducts = products.Count()
            };

            return PartialView("_ProductList", viewModel);
        }

        public IActionResult Details(int id)
        {
            var product = SampleData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // WARNING: This is deliberately vulnerable to SQL injection!
        public IActionResult Search(string searchTerm)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                // Vulnerable code: Direct string concatenation in SQL query
                var sql = "SELECT * FROM Products WHERE Name LIKE @SearchTerm OR Description LIKE @SearchTerm";
                var products = connection.Query<Product>(sql, new { SearchTerm = "%" + searchTerm + "%" }).ToList();
                return View("Index", products);
            }
        }
    }
}