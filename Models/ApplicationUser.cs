using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace magero_store.Models
{
    /// <summary>
    /// Modelo de usuario de la aplicación que extiende IdentityUser.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Nombre completo del usuario.
        /// </summary>
        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre completo no puede exceder 100 caracteres")]
        [Display(Name = "Nombre completo")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de registro del usuario.
        /// </summary>
        [Display(Name = "Fecha de registro")]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Indica si el usuario ha aceptado los términos y condiciones.
        /// </summary>
        [Display(Name = "Términos y condiciones")]
        public bool AcceptedTerms { get; set; }

        /// <summary>
        /// Dirección del usuario (opcional).
        /// </summary>
        [StringLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres")]
        [Display(Name = "Dirección")]
        public string? Address { get; set; }

        /// <summary>
        /// Ciudad del usuario (opcional).
        /// </summary>
        [StringLength(50, ErrorMessage = "La ciudad no puede exceder 50 caracteres")]
        [Display(Name = "Ciudad")]
        public string? City { get; set; }

        /// <summary>
        /// Código postal del usuario (opcional).
        /// </summary>
        [StringLength(10, ErrorMessage = "El código postal no puede exceder 10 caracteres")]
        [Display(Name = "Código postal")]
        public string? PostalCode { get; set; }
    }
}