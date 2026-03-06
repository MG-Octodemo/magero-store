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
        /// Muestra la lista de productos con filtros opcionales por término de búsqueda y rango de precios.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda para filtrar por nombre o descripción del producto.</param>
        /// <param name="minPrice">Precio mínimo para filtrar productos (opcional).</param>
        /// <param name="maxPrice">Precio máximo para filtrar productos (opcional).</param>
        /// <returns>Vista con la lista de productos filtrados.</returns>
        public IActionResult Index(string searchTerm, decimal? minPrice, decimal? maxPrice)
        {
            // Validar parámetros de precio
            if (minPrice.HasValue && minPrice < 0)
            {
                minPrice = null;
            }
            if (maxPrice.HasValue && maxPrice < 0)
            {
                maxPrice = null;
            }
            if (minPrice.HasValue && maxPrice.HasValue && minPrice > maxPrice)
            {
                var temp = minPrice;
                minPrice = maxPrice;
                maxPrice = temp;
            }

            var products = SampleData.Products.AsEnumerable();

            // Filtrar por término de búsqueda si se proporciona
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => 
                    p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            // Filtrar por precio mínimo si se proporciona
            if (minPrice.HasValue)
            {
                products = products.Where(p => p.Price >= minPrice.Value);
            }

            // Filtrar por precio máximo si se proporciona
            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= maxPrice.Value);
            }

            return View(products.ToList());
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
        /// Realiza una búsqueda de productos en la base de datos con filtros por término de búsqueda y rango de precios.
        /// ADVERTENCIA: Este método contiene una vulnerabilidad de inyección SQL deliberada.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda para filtrar por nombre o descripción del producto.</param>
        /// <param name="minPrice">Precio mínimo para filtrar productos (opcional).</param>
        /// <param name="maxPrice">Precio máximo para filtrar productos (opcional).</param>
        /// <returns>Vista con la lista de productos encontrados.</returns>
        // WARNING: This is deliberately vulnerable to SQL injection!
        public IActionResult Search(string searchTerm, decimal? minPrice, decimal? maxPrice)
        {
            // Validar parámetros de precio
            if (minPrice.HasValue && minPrice < 0)
            {
                minPrice = null;
            }
            if (maxPrice.HasValue && maxPrice < 0)
            {
                maxPrice = null;
            }
            if (minPrice.HasValue && maxPrice.HasValue && minPrice > maxPrice)
            {
                var temp = minPrice;
                minPrice = maxPrice;
                maxPrice = temp;
            }

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                
                var sql = "SELECT * FROM Products WHERE 1=1";
                var parameters = new Dictionary<string, object>();

                // Añadir filtro por término de búsqueda
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    sql += " AND (Name LIKE @SearchTerm OR Description LIKE @SearchTerm)";
                    parameters.Add("SearchTerm", "%" + searchTerm + "%");
                }

                // Añadir filtro por precio mínimo
                if (minPrice.HasValue)
                {
                    sql += " AND Price >= @MinPrice";
                    parameters.Add("MinPrice", minPrice.Value);
                }

                // Añadir filtro por precio máximo
                if (maxPrice.HasValue)
                {
                    sql += " AND Price <= @MaxPrice";
                    parameters.Add("MaxPrice", maxPrice.Value);
                }

                var products = connection.Query<Product>(sql, parameters).ToList();
                return View("Index", products);
            }
        }
    }
}