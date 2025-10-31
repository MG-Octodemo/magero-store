# Directrices para Controladores

## 📋 Principios Generales

### Seguridad
- **NUNCA** concatenar strings directamente en consultas SQL
- **SIEMPRE** usar parámetros SQL para prevenir inyección SQL
- **VALIDAR** todos los parámetros de entrada antes de usarlos
- **SANITIZAR** los datos de entrada con métodos como `Trim()`
- **NO EXPONER** detalles internos de errores al usuario

### Validación de Entrada
- Validar que los parámetros no sean nulos o vacíos
- Validar longitud máxima de strings (típicamente 100 caracteres para búsquedas)
- Validar formatos esperados (emails, URLs, etc.)
- Retornar respuestas apropiadas para datos inválidos (BadRequest)

### Manejo de Errores
- Usar bloques try-catch para capturar excepciones
- Capturar `SqlException` específicamente para errores de base de datos
- Capturar `Exception` genérica para otros errores inesperados
- Agregar mensajes de error amigables al `ModelState`
- Retornar códigos de estado HTTP apropiados (400, 500, etc.)
- Incluir TODOs para implementar logging estructurado con ILogger

### Documentación
- Documentar todos los métodos públicos con comentarios XML en español
- Incluir `<summary>` describiendo la funcionalidad del método
- Incluir `<param>` para cada parámetro explicando su propósito
- Incluir `<returns>` describiendo qué devuelve el método
- Agregar comentarios en línea para lógica compleja

### Conexiones a Base de Datos
- Validar que la cadena de conexión exista antes de usarla
- Usar bloques `using` para asegurar la disposición correcta de conexiones
- Especificar columnas explícitamente en SELECT en lugar de usar `*`
- Incluir ORDER BY para resultados consistentes

## 🔒 Ejemplo de Método Seguro

```csharp
/// <summary>
/// Busca productos de manera segura utilizando parámetros SQL.
/// </summary>
/// <param name="searchTerm">Término de búsqueda</param>
/// <returns>Vista con lista de productos</returns>
[HttpGet]
public IActionResult Search(string searchTerm)
{
    // Validación de entrada
    if (string.IsNullOrWhiteSpace(searchTerm))
        return View("Index", new List<Product>());

    if (searchTerm.Length > 100)
    {
        ModelState.AddModelError("searchTerm", "El término de búsqueda es demasiado largo");
        return BadRequest(ModelState);
    }

    try
    {
        // Validación de conexión
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Cadena de conexión no configurada");

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            
            // Consulta SQL segura con parámetros
            var sql = @"SELECT Id, Name, Description, Price, ImageUrl 
                       FROM Products 
                       WHERE Name LIKE @SearchTerm 
                       ORDER BY Name";
            
            var sanitizedSearchTerm = $"%{searchTerm.Trim()}%";
            var products = connection.Query<Product>(sql, new { SearchTerm = sanitizedSearchTerm }).ToList();
            
            return View("Index", products);
        }
    }
    catch (SqlException sqlEx)
    {
        // TODO: Implementar logging con ILogger
        ModelState.AddModelError("", "Error al buscar productos. Intente nuevamente.");
        return View("Index", new List<Product>());
    }
    catch (Exception ex)
    {
        // TODO: Implementar logging con ILogger
        ModelState.AddModelError("", "Error interno del servidor.");
        return StatusCode(500);
    }
}
```

## ⚠️ Antipatrones a Evitar

### ❌ NO Hacer
```csharp
// Concatenación directa - VULNERABLE A SQL INJECTION
var sql = "SELECT * FROM Products WHERE Name = '" + searchTerm + "'";

// Sin validación de entrada
public IActionResult Search(string searchTerm)
{
    var sql = "SELECT * FROM Products WHERE Name LIKE @SearchTerm";
    // Sin validar searchTerm antes de usar
}

// Sin manejo de errores
public IActionResult Search(string searchTerm)
{
    var connection = new SqlConnection(_connectionString);
    connection.Open();
    // Sin try-catch, puede causar excepciones no manejadas
}
```

### ✅ Hacer
```csharp
// Usar parámetros SQL
var sql = "SELECT * FROM Products WHERE Name LIKE @SearchTerm";
var products = connection.Query<Product>(sql, new { SearchTerm = $"%{searchTerm}%" });

// Validar entrada
if (string.IsNullOrWhiteSpace(searchTerm))
    return BadRequest("Término de búsqueda requerido");

// Manejar errores apropiadamente
try { /* código */ }
catch (SqlException ex) { /* manejo específico */ }
catch (Exception ex) { /* manejo general */ }
```

## 📝 Checklist de Revisión

Antes de finalizar un controlador, verificar:

- [ ] Todos los métodos tienen documentación XML en español
- [ ] No hay concatenación directa de strings en consultas SQL
- [ ] Todos los parámetros de entrada están validados
- [ ] Se validan las cadenas de conexión antes de usarlas
- [ ] Hay manejo de errores con try-catch
- [ ] Los mensajes de error son amigables y no exponen detalles internos
- [ ] Se usan bloques `using` para recursos que implementan IDisposable
- [ ] Se especifican columnas explícitas en consultas SELECT
- [ ] Se incluyen TODOs para logging pendiente

## 🔗 Referencias

- [OWASP SQL Injection Prevention](https://cheatsheetseries.owasp.org/cheatsheets/SQL_Injection_Prevention_Cheat_Sheet.html)
- [ASP.NET Core Security Best Practices](https://docs.microsoft.com/en-us/aspnet/core/security/)
- [Dapper Documentation](https://github.com/DapperLib/Dapper)
