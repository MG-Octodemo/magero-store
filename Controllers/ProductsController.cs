using Microsoft.AspNetCore.Mvc;
using magero_store.Models;
using magero_store.Data;
using Microsoft.Data.Sqlite;  // Cambiado de Microsoft.Data.SqlClient para compatibilidad con SQLite
using Dapper;
using System.Linq;

namespace magero_store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IConfiguration configuration, ILogger<ProductsController> logger)
        {
            _configuration = configuration;
            _logger = logger;
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
        /// Realiza una búsqueda de productos en la base de datos usando el término especificado.
        /// Implementa validación robusta y manejo seguro de conexiones SQLite.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda para filtrar productos por nombre o descripción</param>
        /// <returns>Vista con los productos que coinciden con el término de búsqueda</returns>
        public IActionResult Search(string searchTerm)
        {
            try
            {
                // Validación de entrada: verificar parámetro no nulo/vacío/espacios en blanco
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    _logger.LogWarning("Búsqueda realizada con término vacío o nulo");
                    return View("Index", new List<Product>());
                }

                // Validación de longitud máxima para prevenir ataques de DoS
                if (searchTerm.Length > 100)
                {
                    _logger.LogWarning("Término de búsqueda demasiado largo: {Length} caracteres", searchTerm.Length);
                    return View("Index", new List<Product>());
                }

                // Sanitizar término de búsqueda para logging seguro
                var sanitizedTerm = searchTerm.Replace("\r", "").Replace("\n", "").Trim();
                _logger.LogInformation("Realizando búsqueda con término: {SearchTerm}", sanitizedTerm);

                // Usar SqliteConnection para compatibilidad con SQLite configurado
                using (var connection = new SqliteConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    
                    // Query parametrizada segura - Dapper maneja automáticamente la sanitización
                    var sql = "SELECT * FROM Products WHERE Name LIKE @SearchTerm OR Description LIKE @SearchTerm";
                    var products = connection.Query<Product>(sql, new { SearchTerm = "%" + sanitizedTerm + "%" }).ToList();
                    
                    _logger.LogInformation("Búsqueda completada. Productos encontrados: {Count}", products.Count);
                    
                    return View("Index", products);
                }
            }
            catch (SqliteException ex)
            {
                // Manejo específico de errores de SQLite
                _logger.LogError(ex, "Error de base de datos SQLite durante la búsqueda");
                
                // Retornar vista de error sin exponer detalles técnicos
                return View("Index", new List<Product>());
            }
            catch (Exception ex)
            {
                // Manejo general de errores
                _logger.LogError(ex, "Error inesperado durante la búsqueda");
                
                // Retornar vista de error sin exponer información sensible
                return View("Index", new List<Product>());
            }
        }
    }
}