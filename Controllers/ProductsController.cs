using Microsoft.AspNetCore.Mvc;
using magero_store.Models;
using magero_store.Data;
using Microsoft.Data.SqlClient;  // Changed from System.Data.SqlClient
using Dapper;
using System.Linq;
using System.Collections.Generic;

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
        /// Busca productos de manera segura utilizando parámetros SQL para prevenir inyección SQL.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda para filtrar productos por nombre o descripción</param>
        /// <returns>Vista con los productos que coinciden con el término de búsqueda</returns>
        [HttpGet]
        public IActionResult Search(string searchTerm)
        {
            // Validación de parámetros de entrada
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return View("Index", new List<Product>());
            }

            // Validación adicional del término de búsqueda para prevenir ataques
            if (searchTerm.Length > 100)
            {
                ModelState.AddModelError("searchTerm", "El término de búsqueda es demasiado largo");
                return BadRequest(ModelState);
            }

            try
            {
                // Validación de conexión
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Cadena de conexión no configurada");
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    // Consulta SQL segura con parámetros para prevenir inyección SQL
                    var sql = @"SELECT Id, Nombre, Descripcion, Precio, UrlImagen 
                               FROM Products 
                               WHERE Nombre LIKE @SearchTerm 
                                  OR Descripcion LIKE @SearchTerm
                               ORDER BY Nombre";
                    
                    // Sanitización del término de búsqueda
                    var sanitizedSearchTerm = $"%{searchTerm.Trim()}%";
                    
                    var products = connection.Query<Product>(sql, new { SearchTerm = sanitizedSearchTerm }).ToList();
                    
                    return View("Index", products);
                }
            }
            catch (SqlException sqlEx)
            {
                // Log del error (en producción usar un logger apropiado)
                // _logger.LogError(sqlEx, "Error de base de datos al buscar productos");
                
                // No exponer detalles del error al usuario
                ModelState.AddModelError("", "Error al buscar productos. Intente nuevamente.");
                return View("Index", new List<Product>());
            }
            catch (Exception ex)
            {
                // Log del error genérico
                // _logger.LogError(ex, "Error inesperado al buscar productos");
                
                // Respuesta de error genérica
                ModelState.AddModelError("", "Error interno del servidor. Intente nuevamente más tarde.");
                return StatusCode(500);
            }
        }
    }
}