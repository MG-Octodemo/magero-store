using magero_store.Models;
using magero_store.ViewModels;

namespace magero_store.Services
{
    /// <summary>
    /// Interface del servicio de productos.
    /// Define las operaciones disponibles para gestionar productos según el patrón MVC.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Obtiene todos los productos.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        Task<IEnumerable<Product>> GetAllProductsAsync();

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <returns>Producto encontrado o null.</returns>
        Task<Product?> GetProductByIdAsync(int id);

        /// <summary>
        /// Busca productos por término de búsqueda.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda.</param>
        /// <returns>Lista de productos que coinciden con la búsqueda.</returns>
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);

        /// <summary>
        /// Obtiene productos filtrados por rango de precio.
        /// </summary>
        /// <param name="minPrice">Precio mínimo.</param>
        /// <param name="maxPrice">Precio máximo.</param>
        /// <returns>Lista de productos en el rango de precio.</returns>
        Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
    }
}
