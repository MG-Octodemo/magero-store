using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using System.Security.Claims;
using magero_store.Data;
using magero_store.Models;

namespace magero_store.Controllers
{
    /// <summary>
    /// Controlador para gestión de cuentas de usuario y autenticación con Entra ID
    /// </summary>
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ApplicationDbContext context, ILogger<AccountController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Muestra el perfil del usuario autenticado
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            try
            {
                var userId = User.GetObjectId();
                if (string.IsNullOrEmpty(userId))
                {
                    _logger.LogWarning("No se pudo obtener el ID del usuario autenticado");
                    return RedirectToAction("SignIn");
                }

                var user = await GetOrCreateUserAsync(userId);
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar el perfil del usuario");
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Redirige al usuario a la página de inicio de sesión de Entra ID
        /// </summary>
        public IActionResult SignIn()
        {
            var redirectUrl = Url.Action("Index", "Home");
            return Challenge(new Microsoft.AspNetCore.Authentication.AuthenticationProperties { RedirectUri = redirectUrl });
        }

        /// <summary>
        /// Redirige al usuario a la página de registro de Entra ID
        /// </summary>
        public IActionResult SignUp()
        {
            var redirectUrl = Url.Action("Index", "Home");
            return Challenge(new Microsoft.AspNetCore.Authentication.AuthenticationProperties { RedirectUri = redirectUrl });
        }

        /// <summary>
        /// Cierra la sesión del usuario
        /// </summary>
        [Authorize]
        public new IActionResult SignOut()
        {
            var callbackUrl = Url.Action("Index", "Home", values: null, protocol: Request.Scheme);
            return SignOut(new Microsoft.AspNetCore.Authentication.AuthenticationProperties { RedirectUri = callbackUrl });
        }

        /// <summary>
        /// Obtiene o crea un usuario en la base de datos local
        /// </summary>
        private async Task<User> GetOrCreateUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("El ID de usuario no puede estar vacío", nameof(userId));

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                user = new User
                {
                    Id = userId,
                    Email = User.GetDisplayName() ?? "",
                    DisplayName = User.GetDisplayName() ?? "",
                    GivenName = User.FindFirstValue(ClaimTypes.GivenName),
                    Surname = User.FindFirstValue(ClaimTypes.Surname),
                    TwoFactorEnabled = true,
                    CreatedAt = DateTime.UtcNow,
                    LastLoginAt = DateTime.UtcNow
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Usuario creado: {UserId}", userId);
            }
            else
            {
                user.LastLoginAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Usuario actualizado: {UserId}", userId);
            }

            return user;
        }
    }
}