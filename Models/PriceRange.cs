namespace magero_store.Models
{
    /// <summary>
    /// Define los rangos de precio para el filtrado de productos.
    /// </summary>
    public static class PriceRange
    {
        /// <summary>
        /// Constante para el filtro de precio bajo: productos entre $0 y $99.99.
        /// </summary>
        public const string Low = "low";

        /// <summary>
        /// Constante para el filtro de precio medio: productos entre $100 y $299.99.
        /// </summary>
        public const string Medium = "med";

        /// <summary>
        /// Constante para el filtro de precio alto: productos de $300 en adelante.
        /// </summary>
        public const string High = "high";

        /// <summary>
        /// Límite superior para productos de precio bajo.
        /// </summary>
        public const decimal LowMaxPrice = 99.99M;

        /// <summary>
        /// Límite inferior para productos de precio medio.
        /// </summary>
        public const decimal MediumMinPrice = 100.00M;

        /// <summary>
        /// Límite superior para productos de precio medio.
        /// </summary>
        public const decimal MediumMaxPrice = 299.99M;

        /// <summary>
        /// Límite inferior para productos de precio alto.
        /// </summary>
        public const decimal HighMinPrice = 300.00M;

        /// <summary>
        /// Aplica el filtro de precio a una consulta de productos.
        /// </summary>
        /// <param name="products">Lista de productos a filtrar.</param>
        /// <param name="priceFilter">Filtro de precio a aplicar (low, med, high).</param>
        /// <returns>Lista filtrada de productos.</returns>
        public static IEnumerable<Product> ApplyPriceFilter(IEnumerable<Product> products, string? priceFilter)
        {
            if (string.IsNullOrEmpty(priceFilter))
                return products;

            return priceFilter.ToLower() switch
            {
                Low => products.Where(p => p.Price <= LowMaxPrice),
                Medium => products.Where(p => p.Price >= MediumMinPrice && p.Price <= MediumMaxPrice),
                High => products.Where(p => p.Price >= HighMinPrice),
                _ => products
            };
        }
    }
}