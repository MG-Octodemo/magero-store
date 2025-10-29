# Pruebas Unitarias - Magero Store

## 📋 Descripción

Este proyecto contiene pruebas unitarias completas para el modelo `Product` y el controlador `ProductsController` de la aplicación Magero Store, validando las propiedades refactorizadas en español.

## 🧪 Framework de Pruebas

- **xUnit**: Framework de pruebas unitarias
- **Moq**: Framework para crear objetos mock
- **Microsoft.AspNetCore.Mvc.Testing**: Utilidades para pruebas de ASP.NET Core MVC

## 📁 Estructura de Pruebas

```
Tests/
├── Models/
│   └── ProductTests.cs          # Pruebas del modelo Product
├── Controllers/
│   └── ProductsControllerTests.cs # Pruebas del controlador Products
└── GlobalUsings.cs              # Referencias globales
```

## ✅ Cobertura de Pruebas

### Modelo Product (ProductTests.cs)

**Total de pruebas: 8**

1. ✅ `Product_ConDatosValidos_NoGeneraErroresDeValidacion` - Valida que un producto con todos los datos correctos no genere errores
2. ✅ `Product_SinNombre_GeneraErrorDeValidacion` - Verifica que la validación `[Required]` funciona para `Nombre`
3. ✅ `Product_ConNombreVacio_GeneraErrorDeValidacion` - Verifica validación de nombre vacío
4. ✅ `Product_PropiedadesSeAsignanCorrectamente` - Confirma que todas las propiedades se asignan correctamente
5. ✅ `Product_PrecioConDecimales_SeAlmacenaCorrectamente` (Theory con 4 casos) - Valida diferentes valores decimales para `Precio`
6. ✅ `Product_ConDescripcionNula_EsValido` - Verifica que `Descripcion` puede ser nula
7. ✅ `Product_ConImagenUrlNula_EsValido` - Verifica que `ImagenUrl` puede ser nula

### Controlador ProductsController (ProductsControllerTests.cs)

**Total de pruebas: 22**

#### Método Index (7 pruebas)
1. ✅ `Index_SinTerminoDeBusqueda_DevuelveTodosLosProductos`
2. ✅ `Index_ConTerminoVacio_DevuelveTodosLosProductos`
3. ✅ `Index_ConTerminoDeBusqueda_FiltraProductosPorDescripcion`
4. ✅ `Index_BusquedaCaseInsensitive_DevuelveResultados` (Theory con 3 casos)
5. ✅ `Index_SinCoincidencias_DevuelveListaVacia`

#### Método Details (3 pruebas)
6. ✅ `Details_ConIdValido_DevuelveProductoCorrecto`
7. ✅ `Details_ConIdInexistente_DevuelveNotFound`
8. ✅ `Details_ConDiferentesIds_DevuelveProductosCorrectos` (Theory con 3 casos)

#### Método Search (9 pruebas)
9. ✅ `Search_ConTerminoVacio_DevuelveListaVacia`
10. ✅ `Search_ConTerminoNull_DevuelveListaVacia`
11. ✅ `Search_ConTerminoDemasiadoLargo_DevuelveBadRequest` - Valida límite de 100 caracteres
12. ✅ `Search_ConEspaciosEnBlanco_DevuelveListaVacia` (Theory con 4 casos)

#### Otros (3 pruebas)
13. ✅ `Constructor_ConConfiguracionValida_CreaInstancia`

## 🚀 Ejecutar las Pruebas

### Ejecutar todas las pruebas
```bash
cd Tests
dotnet test
```

### Ejecutar pruebas con información detallada
```bash
dotnet test --verbosity detailed
```

### Ejecutar pruebas específicas por nombre
```bash
dotnet test --filter "FullyQualifiedName~ProductTests"
dotnet test --filter "FullyQualifiedName~ProductsControllerTests"
```

### Ver cobertura de pruebas
```bash
dotnet test --collect:"XPlat Code Coverage"
```

## 📊 Resumen de Resultados

```
✅ Total de pruebas: 30
✅ Pasadas: 30
❌ Fallidas: 0
⏭️  Omitidas: 0
⏱️  Duración: ~100ms
```

## 🎯 Propiedades Probadas (en Español)

Las pruebas validan las siguientes propiedades refactorizadas del modelo `Product`:

- ✅ `Id` - Identificador único
- ✅ `Nombre` - Nombre del producto (con validación `[Required]`)
- ✅ `Descripcion` - Descripción del producto
- ✅ `Precio` - Precio con soporte para decimales
- ✅ `ImagenUrl` - URL de la imagen

## 📝 Notas Importantes

1. **Validaciones**: Las pruebas verifican que el atributo `[Required]` funciona correctamente en las propiedades `Nombre` y `Precio`.

2. **Compatibilidad de Tipos**: Se verifica que el tipo `decimal` maneje correctamente diferentes valores para `Precio`.

3. **Nullabilidad**: Las pruebas confirman que `Descripcion` e `ImagenUrl` pueden ser nulas, mientras que `Nombre` es requerido.

4. **Búsquedas**: Se prueba la funcionalidad de búsqueda case-insensitive por descripción y la validación de parámetros de entrada.

5. **Seguridad**: Las pruebas del método `Search` verifican las validaciones de seguridad implementadas (longitud máxima, términos vacíos, etc.).

## 🔧 Mantenimiento

Para agregar nuevas pruebas:

1. Agregar el método de prueba con el atributo `[Fact]` o `[Theory]`
2. Seguir la convención de nombres: `MetodoQueSeProba_Condicion_ResultadoEsperado`
3. Usar comentarios XML en español para documentar cada prueba
4. Ejecutar `dotnet test` para verificar que todas las pruebas pasen

## 📚 Recursos

- [xUnit Documentation](https://xunit.net/)
- [Moq Documentation](https://github.com/moq/moq4)
- [ASP.NET Core Testing](https://docs.microsoft.com/en-us/aspnet/core/test/)
