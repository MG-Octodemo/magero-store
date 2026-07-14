using Microsoft.AspNetCore.Mvc;
using magero_store.Models;
using magero_store.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace magero_store.Controllers
{
    /// <summary>
    /// Controlador para la gestión de productos en la tienda
    /// </summary>
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductsController> _logger;

        /// <summary>
        /// Constructor del controlador de productos
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación</param>
        /// <param name="logger">Logger para diagnóstico</param>
        public ProductsController(IConfiguration configuration, ILogger<ProductsController> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Muestra la lista de productos con opción de búsqueda
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda opcional</param>
        /// <returns>Vista con la lista de productos filtrada</returns>
        public IActionResult Index(string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
            {
                return View(SampleData.Products);
            }

            var products = SampleData.Products;
            products = products.Where(p => p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            return View(products);
        }

        /// <summary>
        /// Muestra los detalles de un producto específico
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>Vista con los detalles del producto</returns>
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
        /// Realiza una búsqueda segura de productos en la base de datos
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda para filtrar productos</param>
        /// <returns>Vista con los resultados de la búsqueda</returns>
        public IActionResult Search(string searchTerm)
        {
            try
            {
                // Validación de parámetros de entrada
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    _logger.LogInformation("Búsqueda realizada sin término de búsqueda");
                    return View("Index", new List<Product>());
                }

                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está configurada");
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    const string sql = @"
                        SELECT * 
                        FROM Products 
                        WHERE Name LIKE @SearchTerm 
                        OR Description LIKE @SearchTerm";

                    var parameters = new { SearchTerm = $"%{searchTerm}%" };
                    var products = connection.Query<Product>(sql, parameters).ToList();

                    _logger.LogInformation(
                        "Búsqueda completada. Término: {SearchTerm}, Resultados: {ResultCount}", 
                        searchTerm, 
                        products.Count);

                    return View("Index", products);
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al realizar la búsqueda en la base de datos");
                ModelState.AddModelError(string.Empty, "Error al realizar la búsqueda. Por favor, inténtelo de nuevo.");
                return View("Index", new List<Product>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al realizar la búsqueda");
                ModelState.AddModelError(string.Empty, "Ha ocurrido un error inesperado. Por favor, inténtelo de nuevo.");
                return View("Index", new List<Product>());
            }
        }
    }
}
