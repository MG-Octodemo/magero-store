using magero_store.Data;
using magero_store.Models;
using Microsoft.EntityFrameworkCore;

namespace magero_store.Services
{
    /// <summary>
    /// Implementación del servicio de productos.
    /// Gestiona la lógica de negocio de productos separada del controlador (patrón MVC).
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor del servicio de productos.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        public ProductService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Obtiene todos los productos de la base de datos.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un producto específico por su ID.
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <returns>Producto encontrado o null si no existe.</returns>
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            if (id <= 0) return null;

            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Busca productos por nombre o descripción.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda.</param>
        /// <returns>Lista de productos que coinciden con la búsqueda.</returns>
        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllProductsAsync();
            }

            // Búsqueda segura usando parámetros (previene SQL injection)
            return await _context.Products
                .Where(p => EF.Functions.Like(p.Name, $"%{searchTerm}%") ||
                           EF.Functions.Like(p.Description, $"%{searchTerm}%"))
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene productos filtrados por rango de precio.
        /// </summary>
        /// <param name="minPrice">Precio mínimo.</param>
        /// <param name="maxPrice">Precio máximo.</param>
        /// <returns>Lista de productos en el rango de precio especificado.</returns>
        public async Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            if (minPrice < 0) minPrice = 0;
            if (maxPrice < minPrice) maxPrice = decimal.MaxValue;

            return await _context.Products
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .OrderBy(p => p.Price)
                .ToListAsync();
        }
    }
}
