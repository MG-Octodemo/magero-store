namespace magero_store.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public required string UrlImagen { get; set; }
    }
}
