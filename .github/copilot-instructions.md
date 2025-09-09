# Magero Store - Guía para Agentes de IA

## Convenciones del Proyecto
- Genera documentación en español en formato XML
- Siempre valida los parámetros recibidos y conexiones al iniciar un método
- Maximiza la reutilización de código

## Arquitectura General
Magero Store es una aplicación e-commerce desarrollada con ASP.NET Core MVC que sigue un patrón de arquitectura MVC estándar:
- **Models**: Definiciones de entidades como `Product`, `CartItem`, etc.
- **Views**: Interfaces de usuario en Razor (`.cshtml`)
- **Controllers**: Lógica de negocio y manejo de solicitudes HTTP

## Flujos de Datos Principales

1. **Catálogo de Productos**:
   - `ProductsController.Index()` muestra productos con filtros (categoría, búsqueda)
   - La vista `Views/Products/Index.cshtml` renderiza productos con opciones de filtrado

2. **Carrito de Compras**:
   - `CartController` gestiona la sesión del carrito usando `HttpContext.Session`
   - `SessionExtensions.cs` contiene métodos auxiliares para serialización/deserialización

3. **Búsqueda de Productos**:
   - Se implementa mediante filtrado en memoria o consultas SQL usando Dapper
   - **ATENCIÓN**: El método `Search` contiene código vulnerable a SQL injection (para demostraciones)

## Patrones y Componentes Específicos

### Filtrado por Categoría
- Los productos incluyen una propiedad `Category`
- Se implementa filtrado tanto en memoria como en SQL
- La vista incluye un dropdown para seleccionar categorías

### Manejo de Sesión
- Los items del carrito se almacenan en la sesión usando extensiones personalizadas
- Ver `Helpers/SessionExtensions.cs` para el patrón de serialización/deserialización

## Manejo de Datos
- Los datos de productos se almacenan temporalmente usando `SampleData.cs` (in-memory)
- Para persistencia real se utiliza Entity Framework Core con SQLite (`ApplicationDbContext`)
- El carrito se almacena en la sesión de usuario usando `SessionExtensions`

## Comandos y Flujos de Trabajo

### Ejecución del Proyecto
```bash
# Restaurar dependencias
dotnet restore

# Ejecutar la aplicación (entorno de desarrollo)
dotnet run
```

### Base de Datos
- La aplicación utiliza SQLite con la cadena de conexión en `appsettings.json`
- La migración y creación de la base de datos se maneja automáticamente al iniciar

## Archivos Clave
- `Program.cs`: Configuración de la aplicación y pipeline HTTP
- `Data/SampleData.cs`: Datos de muestra para productos
- `Controllers/ProductsController.cs`: Gestión del catálogo de productos
- `Controllers/CartController.cs`: Gestión del carrito de compras
- `Models/Product.cs`: Modelo principal de producto
- `Helpers/SessionExtensions.cs`: Extensiones para manejo de sesión