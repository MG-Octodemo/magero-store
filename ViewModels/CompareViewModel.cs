using magero_store.Models;

namespace magero_store.ViewModels
{
    public class CompareViewModel
    {
        public Product? Product1 { get; set; }
        public Product? Product2 { get; set; }
        public required IEnumerable<Product> AllProducts { get; set; }
    }
}
