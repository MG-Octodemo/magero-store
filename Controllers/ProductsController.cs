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

        public IActionResult Index(string searchTerm, string category)
        {
            var products = SampleData.Products;

            // Aplicamos filtro por categoría si está especificada
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category).ToList();
            }

            // Aplicamos filtro por término de búsqueda si está especificado
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Obtenemos lista de categorías disponibles para el dropdown
            ViewBag.Categories = SampleData.Products.Select(p => p.Category).Distinct().OrderBy(c => c).ToList();
            ViewBag.SelectedCategory = category;
            ViewBag.SearchTerm = searchTerm;

            return View(products);
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