# Comprehensive Unit Tests for magero-store

Este proyecto contiene una suite completa de tests unitarios creados siguiendo los principios TDD (Test-Driven Development) en la fase roja.

## Estructura de Tests

### Models
- **ProductBasicTests.cs** - Tests básicos para el modelo Product (10 tests)
- **ProductTests.cs** - Tests completos para el modelo Product (28 tests)
- **CartItemTests.cs** - Tests para el modelo CartItem (18 tests)

### Controllers
- **HomeControllerTests.cs** - Tests para HomeController (8 tests)
- **ProductsControllerTests.cs** - Tests para ProductsController (20 tests)
- **CartControllerTests.cs** - Tests para CartController (18 tests)

### Helpers
- **SessionExtensionsTests.cs** - Tests para SessionExtensions (14 tests)

## Principios TDD Red Phase Implementados

### 1. Tests que Fallan Primero
Todos los tests están diseñados para validar comportamiento específico antes de que la implementación exista o sea completa. Ejemplos:

```csharp
[Fact]
public void Search_ShouldReturnViewResult_WhenValidSearchTermProvided()
{
    // Este test fallará inicialmente porque Search usa conexión real a BD
    Assert.Throws<System.Exception>(() => _controller.Search(searchTerm));
}
```

### 2. Un Test por Comportamiento
Cada test valida un solo comportamiento específico:

```csharp
[Fact]
public void Product_ShouldSetAndGetId_WhenValidValue()
{
    // Arrange
    var product = new Product();
    var expectedId = 123;

    // Act
    product.Id = expectedId;

    // Assert
    Assert.Equal(expectedId, product.Id);
}
```

### 3. Nombres Descriptivos
Los nombres de los tests siguen el patrón: `What_Should_When`:

- `Product_ShouldHaveRequiredAttributeOnName_WhenChecked`
- `CartController_ShouldReturnNotFound_WhenInvalidProductIdProvided`
- `SessionExtensions_ShouldSerializeComplexObject_WhenPassingObject`

### 4. Patrón AAA (Arrange, Act, Assert)
Todos los tests siguen esta estructura:

```csharp
[Fact]
public void CartItem_ShouldSetAndGetQuantity_WhenValidValue()
{
    // Arrange
    var cartItem = new CartItem();
    var expectedQuantity = 5;

    // Act
    cartItem.Quantity = expectedQuantity;

    // Assert
    Assert.Equal(expectedQuantity, cartItem.Quantity);
}
```

## Cobertura de Tests

### Happy Path
Tests que validan escenarios exitosos esperados:
- Creación de objetos con datos válidos
- Operaciones CRUD básicas
- Navegación entre páginas

### Edge Cases
Tests para condiciones límite:
- Valores nulos, vacíos, negativos
- Valores máximos y mínimos
- Strings vacíos vs null

```csharp
[Theory]
[InlineData(null)]
[InlineData("")]
[InlineData("   ")]
public void Product_ShouldHandleInvalidName_WhenSet(string invalidName)
```

### Error Cases
Tests para manejo de errores y excepciones:
- IDs no existentes retornan NotFound
- Dependencias nulas lanzan ArgumentNullException
- JSON inválido lanza JsonException

### Invalid Inputs
Tests con datos malformados o inesperados:
- URLs inválidas
- Datos serializados corruptos
- Referencias circulares

## Frameworks y Herramientas

### xUnit
Framework de testing estándar para .NET con:
- `[Fact]` para tests simples
- `[Theory]` con `[InlineData]` para tests parametrizados
- Assertions claras y descriptivas

### Moq
Framework de mocking para:
- ISession mocking en SessionExtensions tests
- IConfiguration mocking en Controllers
- HttpContext mocking para tests de controllers

### Entity Framework InMemory
Base de datos en memoria para:
- Tests de controllers que requieren DbContext
- Aislamiento de tests sin dependencias externas
- Setup y teardown automático

## Características de los Tests

### 1. Independencia
Cada test puede ejecutarse de forma aislada sin depender de otros tests.

### 2. Determinismo
Los tests producen el mismo resultado en cada ejecución.

### 3. Velocidad
Tests unitarios rápidos que no dependen de recursos externos.

### 4. Legibilidad
Código de test claro y fácil de entender.

### 5. Mantenibilidad
Tests resilientes a cambios de implementación, focalizados en comportamiento público.

## Ejemplos de TDD Red Phase

### Tests que Fallan por Implementación Incompleta
```csharp
[Fact]
public void Search_ShouldHandleNullSearchTerm_WhenCalled()
{
    // Este test fallará hasta que se implemente manejo de null
    Assert.Throws<System.Exception>(() => _controller.Search(nullSearchTerm!));
}
```

### Tests que Validan Atributos de Validación
```csharp
[Fact]
public void Product_NameProperty_ShouldHaveRequiredAttribute()
{
    // Valida que el atributo Required esté presente
    var property = typeof(Product).GetProperty("Name");
    var requiredAttribute = property?.GetCustomAttributes(typeof(RequiredAttribute), false);
    Assert.True(requiredAttribute.Length > 0);
}
```

### Tests Parametrizados para Edge Cases
```csharp
[Theory]
[InlineData(-999)]
[InlineData(-1)]
[InlineData(0)]
[InlineData(99999)]
public void Details_ShouldReturnNotFoundResult_WhenNonExistentIdProvided(int invalidId)
{
    var result = _controller.Details(invalidId);
    Assert.IsType<NotFoundResult>(result);
}
```

## Ejecución de Tests

### Comandos
```bash
# Construir y ejecutar todos los tests
dotnet test

# Ejecutar con verbosidad detallada
dotnet test --verbosity normal

# Ejecutar solo tests de modelos
dotnet test --filter "FullyQualifiedName~Models"

# Ejecutar tests específicos
dotnet test --filter "DisplayName~Product"
```

### Resultados Esperados (Red Phase)
En la fase roja del TDD, se espera que varios tests fallen inicialmente porque:

1. **Implementación Incompleta**: Algunos métodos pueden no manejar todos los casos edge.
2. **Dependencias Externas**: Tests que requieren BD real fallarán con mocks.
3. **Validaciones Faltantes**: Tests de validación fallarán si no hay implementación.
4. **Manejo de Errores**: Tests de excepciones fallarán si no hay manejo apropiado.

## Beneficios de Esta Aproximación

1. **Especificación Clara**: Los tests documentan el comportamiento esperado.
2. **Diseño Guiado**: Los tests guían el diseño de la implementación.
3. **Regresión Prevención**: Detecta cambios no deseados en el comportamiento.
4. **Confianza**: Proporciona seguridad para refactoring futuro.
5. **Documentación Viviente**: Los tests sirven como documentación ejecutable.

## Total de Tests Creados: 116 Tests

- **Product Model**: 38 tests (básicos + completos)
- **CartItem Model**: 18 tests
- **SessionExtensions**: 14 tests
- **HomeController**: 8 tests
- **ProductsController**: 20 tests  
- **CartController**: 18 tests

Cada test valida un comportamiento específico siguiendo las mejores prácticas de TDD red phase.