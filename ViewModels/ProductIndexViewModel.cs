using magero_store.Models;

namespace magero_store.ViewModels
{
    /// <summary>
    /// ViewModel para la vista de índice de productos que incluye filtros de categoría.
    /// </summary>
    public class ProductIndexViewModel
    {
        /// <summary>
        /// Lista de productos a mostrar.
        /// </summary>
        public List<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Lista de categorías disponibles para filtrar.
        /// </summary>
        public List<string> Categories { get; set; } = new List<string>();

        /// <summary>
        /// Categoría actualmente seleccionada para el filtro.
        /// </summary>
        public string? SelectedCategory { get; set; }

        /// <summary>
        /// Término de búsqueda actual.
        /// </summary>
        public string? SearchTerm { get; set; }
    }
}