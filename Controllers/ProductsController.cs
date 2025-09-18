using Microsoft.AspNetCore.Mvc;
using magero_store.Models;
using magero_store.Data;
using Microsoft.Data.SqlClient;  // Changed from System.Data.SqlClient
using Dapper;
using System.Linq;
using System.Text.RegularExpressions;

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
        /// Realiza una búsqueda segura de productos en memoria.
        /// Implementa validaciones de entrada y manejo de errores para prevenir ataques de entrada.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda - validado y sanitizado</param>
        /// <returns>Vista con los productos encontrados</returns>
        public IActionResult Search(string searchTerm)
        {
            try
            {
                // Validación de entrada: verificar parámetros nulos o vacíos
                if (string.IsNullOrEmpty(searchTerm))
                {
                    _logger.LogInformation("Búsqueda realizada con término vacío, retornando vista vacía");
                    return View("Index", new List<Product>());
                }

                // Validación de longitud para prevenir ataques de DoS
                if (searchTerm.Length > 100)
                {
                    _logger.LogWarning("Intento de búsqueda con término demasiado largo: {Length} caracteres", searchTerm.Length);
                    ModelState.AddModelError("searchTerm", "El término de búsqueda es demasiado largo (máximo 100 caracteres)");
                    return View("Index", new List<Product>());
                }

                // Sanitización del término de búsqueda: remover caracteres especiales potencialmente peligrosos
                var sanitizedSearchTerm = SanitizeSearchTerm(searchTerm);
                
                if (string.IsNullOrEmpty(sanitizedSearchTerm))
                {
                    _logger.LogWarning("Término de búsqueda completamente sanitizado resultó vacío");
                    return View("Index", new List<Product>());
                }

                _logger.LogInformation("Realizando búsqueda segura con término sanitizado");

                // Búsqueda segura en los datos en memoria
                var products = SampleData.Products
                    .Where(p => p.Name.Contains(sanitizedSearchTerm, StringComparison.OrdinalIgnoreCase) || 
                               p.Description.Contains(sanitizedSearchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                
                _logger.LogInformation("Búsqueda completada exitosamente. Productos encontrados: {Count}", products.Count);
                
                return View("Index", products);
            }
            catch (Exception ex)
            {
                // Manejo general de errores
                _logger.LogError(ex, "Error inesperado durante búsqueda: {ErrorMessage}", ex.Message);
                ModelState.AddModelError("", "Error interno del servidor. Por favor, intente nuevamente.");
                return View("Index", new List<Product>());
            }
        }

        /// <summary>
        /// Sanitiza el término de búsqueda removiendo caracteres potencialmente peligrosos.
        /// Permite solo letras, números, espacios y algunos caracteres especiales básicos.
        /// </summary>
        /// <param name="input">Término de búsqueda original</param>
        /// <returns>Término sanitizado</returns>
        private string SanitizeSearchTerm(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // Remover caracteres potencialmente peligrosos manteniendo funcionalidad de búsqueda
            // Permite: letras, números, espacios, guiones, puntos y apostrofes
            var regex = new Regex(@"[^a-zA-Z0-9\s\-\.'áéíóúñÁÉÍÓÚÑ]", RegexOptions.Compiled);
            var sanitized = regex.Replace(input, "").Trim();
            
            // Normalizar espacios múltiples
            sanitized = Regex.Replace(sanitized, @"\s+", " ", RegexOptions.Compiled);
            
            return sanitized;
        }
    }
}