namespace magero_store.Models
{
    /// <summary>
    /// Constantes que definen las categorías de productos disponibles.
    /// </summary>
    public static class Categories
    {
        /// <summary>
        /// Categoría para productos electrónicos.
        /// </summary>
        public const string Electronics = "Electronics";

        /// <summary>
        /// Categoría para ropa y accesorios de moda.
        /// </summary>
        public const string Clothing = "Clothing";

        /// <summary>
        /// Categoría para libros y material educativo.
        /// </summary>
        public const string Books = "Books";

        /// <summary>
        /// Categoría para accesorios diversos.
        /// </summary>
        public const string Accessories = "Accessories";

        /// <summary>
        /// Categoría para electrodomésticos.
        /// </summary>
        public const string Appliances = "Appliances";

        /// <summary>
        /// Obtiene todas las categorías disponibles.
        /// </summary>
        /// <returns>Lista de todas las categorías.</returns>
        public static List<string> GetAllCategories()
        {
            return new List<string>
            {
                Electronics,
                Clothing,
                Books,
                Accessories,
                Appliances
            };
        }
    }
}