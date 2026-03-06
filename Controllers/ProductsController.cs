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
            products = products.Where(p => p.Descripcion.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
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
        /// Realiza una búsqueda segura de productos en la base de datos.
        /// Implementa validación de entrada y escapado de caracteres especiales de LIKE.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda proporcionado por el usuario.</param>
        /// <returns>Vista con los productos que coinciden con el término de búsqueda.</returns>
        public IActionResult Search(string searchTerm)
        {
            // Validación de entrada: verificar que searchTerm no sea nulo o vacío
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return View("Index", new List<Product>());
            }

            // Validación de longitud: limitar el término de búsqueda a 100 caracteres
            if (searchTerm.Length > 100)
            {
                searchTerm = searchTerm.Substring(0, 100);
            }

            // Sanitizar el término de búsqueda: escapar caracteres especiales de LIKE
            searchTerm = EscapeLikeParameter(searchTerm);

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    
                    // Consulta SQL segura con parámetros
                    // El patrón LIKE se construye de forma segura dentro del parámetro
                    var sql = "SELECT * FROM Products WHERE Nombre LIKE @SearchTerm OR Descripcion LIKE @SearchTerm";
                    
                    // El patrón se construye aquí de forma segura después de sanitizar
                    var searchPattern = "%" + searchTerm + "%";
                    
                    var products = connection.Query<Product>(sql, new { SearchTerm = searchPattern }).ToList();
                    return View("Index", products);
                }
            }
            catch (SqlException)
            {
                // Logging de errores (en producción, usar un logger apropiado)
                // Por ahora, retornar lista vacía en caso de error
                return View("Index", new List<Product>());
            }
        }

        /// <summary>
        /// Escapa caracteres especiales de LIKE para prevenir inyección SQL.
        /// </summary>
        /// <param name="parameter">Parámetro a escapar.</param>
        /// <returns>Parámetro escapado de forma segura.</returns>
        private string EscapeLikeParameter(string parameter)
        {
            // Escapar caracteres especiales de LIKE: %, _, [, ]
            return parameter
                .Replace("[", "[[]")
                .Replace("%", "[%]")
                .Replace("_", "[_]");
        }
    }
}