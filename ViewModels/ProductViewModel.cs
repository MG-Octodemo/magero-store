using magero_store.Models;

namespace magero_store.ViewModels
{
    /// <summary>
    /// ViewModel para mostrar productos individuales.
    /// </summary>
    public class ProductViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string ImageUrl { get; set; }
    }

    /// <summary>
    /// ViewModel para la página de productos con filtros.
    /// </summary>
    public class ProductsIndexViewModel
    {
        /// <summary>
        /// Lista de productos a mostrar.
        /// </summary>
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

        /// <summary>
        /// Rango de precios seleccionado.
        /// </summary>
        public PriceRange SelectedPriceRange { get; set; } = PriceRange.All;

        /// <summary>
        /// Precio mínimo personalizado.
        /// </summary>
        public decimal? CustomMinPrice { get; set; }

        /// <summary>
        /// Precio máximo personalizado.
        /// </summary>
        public decimal? CustomMaxPrice { get; set; }

        /// <summary>
        /// Término de búsqueda actual.
        /// </summary>
        public string? SearchTerm { get; set; }

        /// <summary>
        /// Número total de productos encontrados.
        /// </summary>
        public int TotalProducts { get; set; }
    }
}
