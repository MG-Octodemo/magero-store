# Pruebas Unitarias para magero-store

Este directorio contiene las pruebas unitarias para todos los métodos de los controladores de la aplicación magero-store.

## Estructura de las Pruebas

### HomeControllerTests.cs
- `Index_DebeRetornarVistaConProductos()` - Verifica que Index devuelve una vista con la lista de productos
- `Error_DebeRetornarVistaDeError()` - Verifica que Error devuelve una vista de error

### ProductsControllerTests.cs
- `Index_SinTerminoBusqueda_DebeRetornarTodosLosProductos()` - Verifica que Index sin término de búsqueda devuelve todos los productos
- `Index_ConTerminoVacio_DebeRetornarTodosLosProductos()` - Verifica que Index con término vacío devuelve todos los productos
- `Index_ConTerminoBusqueda_DebeRetornarProductosFiltrados()` - Verifica que Index filtra correctamente por término de búsqueda
- `Details_ConIdValido_DebeRetornarProducto()` - Verifica que Details devuelve el producto correcto
- `Details_ConIdInvalido_DebeRetornarNotFound()` - Verifica que Details devuelve NotFound para ID inválido
- `Configuration_DebeEstarInicializadaCorrectamente()` - Verifica la configuración del controlador

### CartControllerTests.cs
- `Constructor_ConContextoValido_DebeInicializarCorrectamente()` - Verifica la inicialización del controlador
- `AddToCart_ConProductoInvalido_DebeRetornarNotFound()` - Verifica el manejo de productos inválidos
- `Context_DebeTenerDatosDePrueba()` - Verifica la configuración de datos de prueba
- `Context_ProductsDbSet_DebeEstarConfigurado()` - Verifica la configuración del DbSet de productos
- `Context_Find_DebeBuscarProductosPorId()` - Verifica la búsqueda de productos por ID

## Ejecución de las Pruebas

Para ejecutar las pruebas unitarias:

```bash
cd Tests
dotnet test
```

## Características de las Pruebas

- **Framework**: MSTest
- **Cobertura**: Todos los métodos públicos de los controladores
- **Documentación**: Comentarios XML en español
- **Validación**: Verificación de parámetros y conexiones al iniciar
- **Mockeo**: Uso de configuración in-memory para testing
- **Base de datos**: Entity Framework InMemory para CartController

## Resultados

Las pruebas validan:
- ✅ Inicialización correcta de controladores
- ✅ Validación de parámetros de entrada
- ✅ Tipos de retorno correctos (ViewResult, NotFoundResult, etc.)
- ✅ Filtrado de productos por término de búsqueda
- ✅ Manejo de casos inválidos
- ✅ Configuración de dependencias
- ✅ Acceso a datos de Entity Framework

Total: 13 pruebas que validan todos los métodos de los controladores.