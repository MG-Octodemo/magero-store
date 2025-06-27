using Microsoft.AspNetCore.Mvc;
using magero_store.Models;
using magero_store.ViewModels;
using magero_store.Data;
using magero_store.Helpers;
using Microsoft.Data.SqlClient;  // Changed from System.Data.SqlClient
using Dapper;
using System.Linq;

namespace magero_store.Controllers
{
    /// <summary>
    /// Controlador para la gestión de productos.
    /// </summary>
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor del controlador de productos.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación</param>
        public ProductsController(IConfiguration configuration)
        {
            // Validar parámetros recibidos al iniciar el método
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Muestra la lista de productos con funcionalidad de búsqueda.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda opcional</param>
        /// <returns>Vista con la lista de productos</returns>
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

        /// <summary>
        /// Muestra los detalles de un producto específico.
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>Vista con los detalles del producto</returns>
        public IActionResult Details(int id)
        {
            // Validar parámetros recibidos
            if (id <= 0)
            {
                return BadRequest("ID de producto inválido.");
            }

            var product = SampleData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        /// <summary>
        /// Muestra el formulario para crear un nuevo producto.
        /// </summary>
        /// <returns>Vista del formulario de creación</returns>
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                Name = "",
                Description = "",
                ImageUrl = "",
                Color = ""
            };
            ViewBag.AvailableColors = ColorHelper.ValidColors;
            return View(viewModel);
        }

        /// <summary>
        /// Procesa la creación de un nuevo producto.
        /// </summary>
        /// <param name="viewModel">Datos del producto a crear</param>
        /// <returns>Redirección o vista con errores</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel viewModel)
        {
            // Validar parámetros recibidos
            if (viewModel == null)
            {
                return BadRequest("Datos del producto requeridos.");
            }

            // Normalizar el color antes de la validación
            viewModel.Color = ColorHelper.NormalizeColor(viewModel.Color) ?? viewModel.Color;

            if (ModelState.IsValid)
            {
                // Crear nuevo producto
                var newProduct = new Product
                {
                    Id = SampleData.Products.Max(p => p.Id) + 1,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    Price = viewModel.Price,
                    ImageUrl = viewModel.ImageUrl,
                    Color = viewModel.Color
                };

                SampleData.Products.Add(newProduct);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.AvailableColors = ColorHelper.ValidColors;
            return View(viewModel);
        }

        /// <summary>
        /// Muestra el formulario para editar un producto existente.
        /// </summary>
        /// <param name="id">Identificador del producto a editar</param>
        /// <returns>Vista del formulario de edición</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Validar parámetros recibidos
            if (id <= 0)
            {
                return BadRequest("ID de producto inválido.");
            }

            var product = SampleData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Color = product.Color
            };

            ViewBag.AvailableColors = ColorHelper.ValidColors;
            return View(viewModel);
        }

        /// <summary>
        /// Procesa la edición de un producto existente.
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <param name="viewModel">Datos actualizados del producto</param>
        /// <returns>Redirección o vista con errores</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductViewModel viewModel)
        {
            // Validar parámetros recibidos
            if (id <= 0)
            {
                return BadRequest("ID de producto inválido.");
            }

            if (viewModel == null)
            {
                return BadRequest("Datos del producto requeridos.");
            }

            if (id != viewModel.Id)
            {
                return BadRequest("ID de producto no coincide.");
            }

            // Normalizar el color antes de la validación
            viewModel.Color = ColorHelper.NormalizeColor(viewModel.Color) ?? viewModel.Color;

            var product = SampleData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Actualizar producto
                product.Name = viewModel.Name;
                product.Description = viewModel.Description;
                product.Price = viewModel.Price;
                product.ImageUrl = viewModel.ImageUrl;
                product.Color = viewModel.Color;

                return RedirectToAction(nameof(Index));
            }

            ViewBag.AvailableColors = ColorHelper.ValidColors;
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