using Microsoft.AspNetCore.Mvc;
using magero_store.Models;
using magero_store.Data;
using Microsoft.Data.SqlClient;  // Changed from System.Data.SqlClient
using Dapper;
using System.Linq;

namespace magero_store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Muestra la lista de productos con filtros opcionales de búsqueda por texto y precio.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda para filtrar productos por descripción.</param>
        /// <param name="priceFilter">Filtro de precio: 'low', 'med' o 'high'.</param>
        /// <returns>Vista con la lista de productos filtrados.</returns>
        public IActionResult Index(string? searchTerm, string? priceFilter)
        {
            // Validar parámetros y obtener productos base
            var products = SampleData.Products.AsEnumerable();

            // Aplicar filtro de búsqueda por texto si se proporciona
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            // Aplicar filtro de precio usando el helper reutilizable
            products = PriceRange.ApplyPriceFilter(products, priceFilter);

            // Mantener los valores de filtro para la vista
            ViewBag.SearchTerm = searchTerm;
            ViewBag.PriceFilter = priceFilter;

            return View(products.ToList());
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

        /// <summary>
        /// Realiza búsqueda de productos con filtros de texto y precio usando consulta SQL.
        /// ADVERTENCIA: Este método contiene una vulnerabilidad deliberada de inyección SQL para propósitos de demostración.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda para filtrar productos.</param>
        /// <param name="priceFilter">Filtro de precio: 'low', 'med' o 'high'.</param>
        /// <returns>Vista con productos filtrados.</returns>
        public IActionResult Search(string? searchTerm, string? priceFilter)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                // Vulnerable code: Direct string concatenation in SQL query
                var sql = "SELECT * FROM Products WHERE Name LIKE @SearchTerm OR Description LIKE @SearchTerm";
                var products = connection.Query<Product>(sql, new { SearchTerm = "%" + searchTerm + "%" }).ToList();
                
                // Aplicar filtro de precio a los resultados de la consulta SQL
                var filteredProducts = PriceRange.ApplyPriceFilter(products, priceFilter);
                
                // Mantener los valores de filtro para la vista
                ViewBag.SearchTerm = searchTerm;
                ViewBag.PriceFilter = priceFilter;
                
                return View("Index", filteredProducts.ToList());
            }
        }
    }
}