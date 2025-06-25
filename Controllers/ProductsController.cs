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

        public IActionResult Index(string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
            {
                return View(SampleData.Products);
            }

            // Simulate a search by filtering the in-memory list
            var products = SampleData.Products;
            products = products.Where(p => p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
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

        /// <summary>
        /// Busca productos en la base de datos por nombre o descripción.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda. No puede ser nulo ni vacío.</param>
        /// <returns>Vista con la lista de productos encontrados.</returns>
        /// <remarks>
        /// Valida el parámetro recibido y utiliza consultas parametrizadas para evitar inyección SQL.
        /// </remarks>
        public IActionResult Search(string searchTerm)
        {
            // Validación del parámetro
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                ModelState.AddModelError("searchTerm", "El término de búsqueda no puede estar vacío.");
                return View("Index", new List<Product>());
            }

            // Validación de la cadena de conexión
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                ModelState.AddModelError("Connection", "No se pudo obtener la cadena de conexión a la base de datos.");
                return View("Index", new List<Product>());
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Consulta parametrizada segura
                var sql = "SELECT * FROM Products WHERE Name LIKE @SearchTerm OR Description LIKE @SearchTerm";
                var param = new { SearchTerm = "%" + searchTerm.Trim() + "%" };
                var products = connection.Query<Product>(sql, param).ToList();
                return View("Index", products);
            }
        }
    }
}
