using System.ComponentModel.DataAnnotations;

namespace magero_store.Models
{
    /// <summary>
    /// Modelo de usuario para autenticación con Entra ID External Identities
    /// </summary>
    public class User
    {
        [Key]
        public string Id { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string DisplayName { get; set; } = string.Empty;

        public string? GivenName { get; set; }

        public string? Surname { get; set; }

        public bool TwoFactorEnabled { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime LastLoginAt { get; set; } = DateTime.UtcNow;
    }
}