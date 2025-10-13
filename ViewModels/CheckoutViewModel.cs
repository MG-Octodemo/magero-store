using System.ComponentModel.DataAnnotations;

namespace magero_store.ViewModels
{
    /// <summary>
    /// ViewModel para el proceso de checkout.
    /// Combina información del carrito con datos de envío.
    /// </summary>
    public class CheckoutViewModel
    {
        /// <summary>
        /// Items del carrito.
        /// </summary>
        public List<CartItemViewModel> CartItems { get; set; } = new();

        /// <summary>
        /// Total del pedido.
        /// </summary>
        public decimal Total => CartItems.Sum(i => i.Subtotal);

        /// <summary>
        /// Nombre del cliente.
        /// </summary>
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        [Display(Name = "Nombre completo")]
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Dirección de envío.
        /// </summary>
        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La dirección debe tener entre 5 y 200 caracteres")]
        [Display(Name = "Dirección")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Ciudad.
        /// </summary>
        [Required(ErrorMessage = "La ciudad es requerida")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "La ciudad debe tener entre 2 y 100 caracteres")]
        [Display(Name = "Ciudad")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Código postal.
        /// </summary>
        [Required(ErrorMessage = "El código postal es requerido")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Código postal inválido")]
        [Display(Name = "Código Postal")]
        public string ZipCode { get; set; } = string.Empty;

        /// <summary>
        /// Email de contacto.
        /// </summary>
        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Teléfono de contacto.
        /// </summary>
        [Phone(ErrorMessage = "Teléfono inválido")]
        [Display(Name = "Teléfono")]
        public string? Phone { get; set; }
    }
}
