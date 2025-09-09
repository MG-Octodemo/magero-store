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
        /// Busca productos por término de búsqueda en nombre y descripción.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda para filtrar productos</param>
        /// <returns>Vista con productos filtrados o mensaje de error</returns>
        public IActionResult Search(string searchTerm)
        {
            // Validar parámetros de entrada
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Si no hay término de búsqueda, mostrar todos los productos
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
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    
                    // Consulta segura usando parámetros para prevenir inyección SQL
                    var sql = "SELECT * FROM Products WHERE Name LIKE @SearchTerm OR Description LIKE @SearchTerm";
                    var searchPattern = $"%{searchTerm}%";
                    var products = connection.Query<Product>(sql, new { SearchTerm = searchPattern }).ToList();
                    
                    // Log de auditoría de seguridad (sanitizar entrada del usuario)
                    var logger = HttpContext.RequestServices.GetService<ILogger<ProductsController>>();
                    var sanitizedSearchTerm = searchTerm?.Replace('\r', ' ').Replace('\n', ' ').Replace('\t', ' ');
                    logger?.LogInformation("Búsqueda de productos ejecutada. Término: {SearchTerm}, Resultados: {Count}", 
                        sanitizedSearchTerm, products.Count);
                    
                    return View("Index", products);
                }
            }
            catch (SqlException sqlEx)
            {
                // Log del error específico de SQL (sanitizar entrada del usuario)
                var logger = HttpContext.RequestServices.GetService<ILogger<ProductsController>>();
                var sanitizedSearchTerm = searchTerm?.Replace('\r', ' ').Replace('\n', ' ').Replace('\t', ' ');
                logger?.LogError(sqlEx, "Error de base de datos al buscar productos. Término: {SearchTerm}", sanitizedSearchTerm);
                
                // Retornar productos de muestra en caso de error de base de datos
                var fallbackProducts = SampleData.Products
                    .Where(p => !string.IsNullOrEmpty(searchTerm) && 
                               ((p.Name?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                               (p.Description?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false)))
                    .ToList();
                
                return View("Index", fallbackProducts);
            }
            catch (Exception ex)
            {
                // Log de errores generales (sanitizar entrada del usuario)
                var logger = HttpContext.RequestServices.GetService<ILogger<ProductsController>>();
                var sanitizedSearchTerm = searchTerm?.Replace('\r', ' ').Replace('\n', ' ').Replace('\t', ' ');
                logger?.LogError(ex, "Error inesperado al buscar productos. Término: {SearchTerm}", sanitizedSearchTerm);
                
                // Retornar todos los productos en caso de error general
                return View("Index", SampleData.Products);
            }
        }
    }
}