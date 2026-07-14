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
        /// Muestra la lista de productos con filtrado opcional por término de búsqueda y categoría.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda para filtrar productos por descripción.</param>
        /// <param name="category">Categoría para filtrar productos.</param>
        /// <returns>Vista con la lista de productos filtrados.</returns>
        public IActionResult Index(string searchTerm, string category)
        {
            // Validar configuración y conexión al iniciar el método
            if (_configuration == null)
            {
                throw new InvalidOperationException("La configuración no está disponible.");
            }

            var products = SampleData.Products.AsEnumerable();

            // Filtrar por categoría si se especifica
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            // Filtrar por término de búsqueda si se especifica
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            // Obtener categorías disponibles para el dropdown
            ViewBag.Categories = SampleData.Products.Select(p => p.Category).Distinct().OrderBy(c => c).ToList();
            ViewBag.SelectedCategory = category;

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