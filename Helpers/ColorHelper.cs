using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace magero_store.Helpers
{
    /// <summary>
    /// Clase auxiliar para validación y manejo de colores de productos.
    /// </summary>
    public static class ColorHelper
    {
        /// <summary>
        /// Lista de colores válidos predefinidos.
        /// </summary>
        public static readonly string[] ValidColors = 
        {
            "Rojo", "Azul", "Verde", "Amarillo", "Negro", "Blanco", 
            "Gris", "Rosa", "Morado", "Naranja", "Marrón", "Plateado", "Dorado"
        };

        /// <summary>
        /// Valida si un color es válido según los criterios establecidos.
        /// </summary>
        /// <param name="color">Color a validar</param>
        /// <returns>True si el color es válido, false en caso contrario</returns>
        public static bool IsValidColor(string? color)
        {
            if (string.IsNullOrWhiteSpace(color))
                return false;

            // Validar que esté en la lista de colores predefinidos
            return ValidColors.Contains(color, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Obtiene una representación normalizada del color.
        /// </summary>
        /// <param name="color">Color a normalizar</param>
        /// <returns>Color normalizado o null si es inválido</returns>
        public static string? NormalizeColor(string? color)
        {
            if (string.IsNullOrWhiteSpace(color))
                return null;

            var validColor = ValidColors.FirstOrDefault(c => 
                string.Equals(c, color, StringComparison.OrdinalIgnoreCase));
            
            return validColor;
        }
    }

    /// <summary>
    /// Atributo de validación personalizado para colores de productos.
    /// </summary>
    public class ValidColorAttribute : ValidationAttribute
    {
        /// <summary>
        /// Mensaje de error por defecto.
        /// </summary>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("El color es requerido.");
            }

            var color = value.ToString();
            if (!ColorHelper.IsValidColor(color))
            {
                var validColorsString = string.Join(", ", ColorHelper.ValidColors);
                return new ValidationResult($"El color debe ser uno de los siguientes: {validColorsString}");
            }

            return ValidationResult.Success;
        }
    }
}