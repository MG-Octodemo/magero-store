using magero_store.Models;

namespace magero_store.Services
{
    /// <summary>
    /// Servicio para filtrar productos según diferentes criterios.
    /// </summary>
    public interface IProductFilterService
    {
        /// <summary>
        /// Filtra productos por rango de precios predefinido.
        /// </summary>
        /// <param name="products">Lista de productos a filtrar</param>
        /// <param name="priceRange">Rango de precios predefinido</param>
        /// <returns>Lista de productos filtrados</returns>
        IEnumerable<Product> FilterByPriceRange(IEnumerable<Product> products, PriceRange priceRange);

        /// <summary>
        /// Filtra productos por rango de precios personalizado.
        /// </summary>
        /// <param name="products">Lista de productos a filtrar</param>
        /// <param name="minPrice">Precio mínimo (opcional)</param>
        /// <param name="maxPrice">Precio máximo (opcional)</param>
        /// <returns>Lista de productos filtrados</returns>
        IEnumerable<Product> FilterByCustomPriceRange(IEnumerable<Product> products, decimal? minPrice, decimal? maxPrice);

        /// <summary>
        /// Obtiene el rango de precios mínimo y máximo para un rango predefinido.
        /// </summary>
        /// <param name="priceRange">Rango predefinido</param>
        /// <returns>Tupla con precio mínimo y máximo</returns>
        (decimal? min, decimal? max) GetPriceRangeValues(PriceRange priceRange);
    }

    /// <summary>
    /// Implementación del servicio de filtrado de productos.
    /// </summary>
    public class ProductFilterService : IProductFilterService
    {
        /// <summary>
        /// Filtra productos por rango de precios predefinido.
        /// </summary>
        /// <param name="products">Lista de productos a filtrar</param>
        /// <param name="priceRange">Rango de precios predefinido</param>
        /// <returns>Lista de productos filtrados</returns>
        public IEnumerable<Product> FilterByPriceRange(IEnumerable<Product> products, PriceRange priceRange)
        {
            if (products == null)
                return Enumerable.Empty<Product>();

            if (priceRange == PriceRange.All)
                return products;

            var (min, max) = GetPriceRangeValues(priceRange);
            return FilterByCustomPriceRange(products, min, max);
        }

        /// <summary>
        /// Filtra productos por rango de precios personalizado.
        /// </summary>
        /// <param name="products">Lista de productos a filtrar</param>
        /// <param name="minPrice">Precio mínimo (opcional)</param>
        /// <param name="maxPrice">Precio máximo (opcional)</param>
        /// <returns>Lista de productos filtrados</returns>
        public IEnumerable<Product> FilterByCustomPriceRange(IEnumerable<Product> products, decimal? minPrice, decimal? maxPrice)
        {
            if (products == null)
                return Enumerable.Empty<Product>();

            var filteredProducts = products.AsQueryable();

            if (minPrice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price <= maxPrice.Value);
            }

            return filteredProducts.ToList();
        }

        /// <summary>
        /// Obtiene el rango de precios mínimo y máximo para un rango predefinido.
        /// </summary>
        /// <param name="priceRange">Rango predefinido</param>
        /// <returns>Tupla con precio mínimo y máximo</returns>
        public (decimal? min, decimal? max) GetPriceRangeValues(PriceRange priceRange)
        {
            return priceRange switch
            {
                PriceRange.All => (null, null),
                PriceRange.Under500 => (null, 499.99m),
                PriceRange.Range500To999 => (500m, 999.99m),
                PriceRange.Range1000To1999 => (1000m, 1999.99m),
                PriceRange.Range2000To4999 => (2000m, 4999.99m),
                PriceRange.Over5000 => (5000m, null),
                PriceRange.Custom => (null, null),
                _ => (null, null)
            };
        }
    }
}