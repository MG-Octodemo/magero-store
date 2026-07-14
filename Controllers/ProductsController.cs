using Microsoft.AspNetCore.Mvc;
using magero_store.Models;
using magero_store.Data;
using Microsoft.Data.Sqlite;  // Cambiado a SQLite para compatibilidad con la configuración de la aplicación
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
        /// Realiza una búsqueda segura de productos en la base de datos SQLite.
        /// Valida la entrada del usuario y utiliza parámetros SQL para prevenir inyección SQL.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda. Debe tener entre 1 y 100 caracteres.</param>
        /// <returns>Vista con los productos que coinciden con el término de búsqueda, o vista de error en caso de fallo.</returns>
        public IActionResult Search(string searchTerm)
        {
            // Validación de entrada para prevenir ataques maliciosos
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Si no hay término de búsqueda, mostrar todos los productos desde SampleData
                return View("Index", SampleData.Products);
            }

            // Validar longitud máxima para prevenir ataques de denegación de servicio
            if (searchTerm.Length > 100)
            {
                ModelState.AddModelError("searchTerm", "El término de búsqueda no puede exceder 100 caracteres.");
                return View("Index", SampleData.Products);
            }

            try
            {
                // Usar SQLiteConnection en lugar de SqlConnection para compatibilidad con la configuración
                using (var connection = new SqliteConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    
                    // Consulta SQL segura usando parámetros - previene inyección SQL
                    var sql = "SELECT * FROM Products WHERE Name LIKE @SearchTerm OR Description LIKE @SearchTerm";
                    
                    // Usar parámetros de Dapper para consulta segura
                    var products = connection.Query<Product>(sql, new { SearchTerm = "%" + searchTerm + "%" }).ToList();
                    
                    return View("Index", products);
                }
            }
            catch (Exception ex)
            {
                // Logging del error para debugging (sin exponer información sensible al usuario)
                // En un entorno de producción, usar un logger apropiado como ILogger
                Console.WriteLine($"Error en búsqueda de productos: {ex.Message}");
                
                // En caso de error, retornar datos de SampleData como fallback
                ModelState.AddModelError("", "Error al realizar la búsqueda. Mostrando productos de ejemplo.");
                return View("Index", SampleData.Products);
            }
        }
    }
}