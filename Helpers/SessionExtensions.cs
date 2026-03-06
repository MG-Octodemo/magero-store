using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace magero_store.Helpers
{
    /// <summary>
    /// Extensiones para facilitar el almacenamiento de objetos en sesión.
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// Serializa y almacena un objeto en la sesión.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto a almacenar.</typeparam>
        /// <param name="session">Sesión actual.</param>
        /// <param name="key">Clave para identificar el objeto.</param>
        /// <param name="value">Valor a almacenar.</param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("La clave no puede estar vacía.", nameof(key));
            }

            session.SetString(key, JsonSerializer.Serialize(value));
        }

        /// <summary>
        /// Recupera y deserializa un objeto de la sesión.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto a recuperar.</typeparam>
        /// <param name="session">Sesión actual.</param>
        /// <param name="key">Clave del objeto almacenado.</param>
        /// <returns>El objeto deserializado o el valor predeterminado si no existe.</returns>
        public static T? Get<T>(this ISession session, string key)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("La clave no puede estar vacía.", nameof(key));
            }

            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
