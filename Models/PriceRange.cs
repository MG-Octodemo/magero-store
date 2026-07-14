namespace magero_store.Models
{
    /// <summary>
    /// Enumeración para los rangos de precios predefinidos.
    /// </summary>
    public enum PriceRange
    {
        /// <summary>
        /// Todos los precios (sin filtro).
        /// </summary>
        All = 0,

        /// <summary>
        /// Menos de $500.
        /// </summary>
        Under500 = 1,

        /// <summary>
        /// Entre $500 y $999.
        /// </summary>
        Range500To999 = 2,

        /// <summary>
        /// Entre $1,000 y $1,999.
        /// </summary>
        Range1000To1999 = 3,

        /// <summary>
        /// Entre $2,000 y $4,999.
        /// </summary>
        Range2000To4999 = 4,

        /// <summary>
        /// $5,000 o más.
        /// </summary>
        Over5000 = 5,

        /// <summary>
        /// Rango personalizado definido por el usuario.
        /// </summary>
        Custom = 6
    }
}