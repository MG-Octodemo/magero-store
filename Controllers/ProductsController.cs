using Microsoft.AspNetCore.Mvc;
using magero_store.Models;
using magero_store.Data;
using magero_store.ViewModels;
using Microsoft.Data.SqlClient;  // Changed from System.Data.SqlClient
using Dapper;
using System.Linq;

namespace magero_store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index(string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
            {
                return View(SampleData.Products);
            }

            // Simulate a search by filtering the in-memory list
            var products = SampleData.Products;
            products = products.Where(p => p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = SampleData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Compare(int? id1, int? id2)
        {
            var allProducts = SampleData.Products;
            var viewModel = new CompareViewModel
            {
                AllProducts = allProducts,
                Product1 = id1.HasValue ? allProducts.FirstOrDefault(p => p.Id == id1.Value) : null,
                Product2 = id2.HasValue ? allProducts.FirstOrDefault(p => p.Id == id2.Value) : null
            };
            return View(viewModel);
        }

        // WARNING: This is deliberately vulnerable to SQL injection!
        public IActionResult Search(string searchTerm)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                // Vulnerable code: Direct string concatenation in SQL query
                var sql = "SELECT * FROM Products WHERE Name LIKE @SearchTerm OR Description LIKE @SearchTerm";
                var products = connection.Query<Product>(sql, new { SearchTerm = "%" + searchTerm + "%" }).ToList();
                return View("Index", products);
            }
        }
    }
}