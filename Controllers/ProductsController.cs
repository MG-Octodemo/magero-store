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
        /// Muestra la lista de productos con filtrado opcional.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda opcional para filtrar productos.</param>
        /// <returns>Vista con la lista de productos.</returns>
        public IActionResult Index(string? searchTerm)
        {
            // Validar que el término de búsqueda no sea excesivamente largo
            if (!string.IsNullOrEmpty(searchTerm) && searchTerm.Length > 100)
            {
                return BadRequest("El término de búsqueda es demasiado largo.");
            }

            if(string.IsNullOrEmpty(searchTerm))
            {
                return View(SampleData.Products);
            }

            // Simulate a search by filtering the in-memory list
            var products = SampleData.Products;
            products = products.Where(p => p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            return View(products);
        }

        /// <summary>
        /// Muestra los detalles de un producto específico.
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <returns>Vista con los detalles del producto o NotFound si no existe.</returns>
        public IActionResult Details(int id)
        {
            // Validar que el ID sea positivo
            if (id <= 0)
            {
                return BadRequest("ID de producto inválido.");
            }

            var product = SampleData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // NOTA: Este método utiliza consultas parametrizadas para prevenir inyección SQL.
        // El uso de @SearchTerm es seguro y previene ataques de SQL injection.
        /// <summary>
        /// Busca productos en la base de datos usando un término de búsqueda.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda.</param>
        /// <returns>Vista con los productos que coinciden con la búsqueda.</returns>
        public IActionResult Search(string? searchTerm)
        {
            // Validar entrada
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return RedirectToAction("Index");
            }

            if (searchTerm.Length > 100)
            {
                return BadRequest("El término de búsqueda es demasiado largo.");
            }

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                // Código seguro: Uso de parámetros para prevenir SQL injection
                var sql = "SELECT * FROM Products WHERE Name LIKE @SearchTerm OR Description LIKE @SearchTerm";
                var products = connection.Query<Product>(sql, new { SearchTerm = "%" + searchTerm + "%" }).ToList();
                return View("Index", products);
            }
        }
    }
}