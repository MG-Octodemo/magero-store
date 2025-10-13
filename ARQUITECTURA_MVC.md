# Arquitectura MVC - Magero Store

## 📐 Patrón Model-View-Controller (MVC)

Este proyecto implementa el patrón arquitectónico **MVC (Model-View-Controller)** siguiendo las mejores prácticas de ASP.NET Core.

---

## 🏗️ Estructura de la Aplicación

```
magero-store/
├── Models/                    # Capa de Modelo (Entidades de dominio)
│   ├── Product.cs            # Entidad Producto
│   └── CartItem.cs           # Entidad Item del Carrito
│
├── ViewModels/                # ViewModels (Modelos de presentación)
│   ├── ProductViewModel.cs   # ViewModel para productos
│   ├── CartViewModel.cs      # ViewModel para carrito
│   └── CheckoutViewModel.cs  # ViewModel para checkout
│
├── Views/                     # Capa de Vista (Presentación)
│   ├── Home/
│   │   └── Index.cshtml      # Vista principal
│   ├── Products/
│   │   ├── Index.cshtml      # Lista de productos
│   │   └── Details.cshtml    # Detalles de producto
│   ├── Cart/
│   │   ├── Index.cshtml      # Vista del carrito
│   │   └── Checkout.cshtml   # Vista de checkout
│   └── Shared/
│       ├── _Layout.cshtml    # Layout principal
│       └── _ViewImports.cshtml
│
├── Controllers/               # Capa de Controlador (Lógica de presentación)
│   ├── HomeController.cs     # Controlador principal
│   ├── ProductsController.cs # Controlador de productos
│   └── CartController.cs     # Controlador del carrito
│
├── Services/                  # Capa de Servicios (Lógica de negocio)
│   ├── IProductService.cs    # Interface del servicio de productos
│   ├── ProductService.cs     # Implementación del servicio de productos
│   ├── ICartService.cs       # Interface del servicio de carrito
│   └── CartService.cs        # Implementación del servicio de carrito
│
├── Data/                      # Capa de Acceso a Datos
│   ├── ApplicationDbContext.cs  # Contexto de EF Core
│   └── SampleData.cs         # Datos de ejemplo
│
└── Program.cs                 # Punto de entrada y configuración
```

---

## 🎯 Componentes del Patrón MVC

### 1️⃣ **Model (Modelo)**
Representa la estructura de datos y las reglas de negocio de la aplicación.

**Ubicación:** `Models/`

**Responsabilidades:**
- Definir entidades de dominio (`Product`, `CartItem`)
- Validaciones de datos mediante Data Annotations
- Representar la estructura de la base de datos

**Ejemplo:**
```csharp
public class Product
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El nombre del producto es requerido")]
    [StringLength(200, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    
    [Range(0.01, 999999.99)]
    public decimal Price { get; set; }
}
```

### 2️⃣ **View (Vista)**
Responsable de la presentación y la interfaz de usuario.

**Ubicación:** `Views/`

**Responsabilidades:**
- Renderizar HTML dinámico con Razor
- Mostrar datos del modelo
- Capturar entrada del usuario
- No contiene lógica de negocio

**Ejemplo:**
```cshtml
@model CartViewModel

<h1>Shopping Cart</h1>
@foreach (var item in Model.Items)
{
    <div>@item.ProductName - @item.Subtotal.ToString("C")</div>
}
```

### 3️⃣ **Controller (Controlador)**
Maneja las solicitudes del usuario y coordina el modelo y la vista.

**Ubicación:** `Controllers/`

**Responsabilidades:**
- Procesar solicitudes HTTP
- Invocar servicios de negocio
- Seleccionar la vista apropiada
- Pasar datos a las vistas mediante ViewModels
- Validar entrada del usuario

**Ejemplo:**
```csharp
public class ProductsController : Controller
{
    private readonly IProductService _productService;
    
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllProductsAsync();
        return View(products);
    }
}
```

---

## 🔧 Capas Adicionales

### 4️⃣ **ViewModels**
Modelos específicos para vistas que combinan o transforman datos del modelo de dominio.

**Ubicación:** `ViewModels/`

**Responsabilidades:**
- Adaptar modelos de dominio para presentación
- Agregar propiedades calculadas
- Validaciones específicas de formularios
- Separar la capa de presentación del modelo de dominio

**Ventajas:**
- ✅ Desacopla la vista del modelo de dominio
- ✅ Permite agregar propiedades computadas sin modificar entidades
- ✅ Facilita validaciones específicas de UI

### 5️⃣ **Services (Capa de Servicios)**
Encapsula la lógica de negocio separada de los controladores.

**Ubicación:** `Services/`

**Responsabilidades:**
- Implementar lógica de negocio compleja
- Coordinar operaciones entre repositorios
- Validaciones de negocio
- Reutilización de código entre controladores

**Patrón utilizado:** Dependency Injection (Inyección de Dependencias)

**Ejemplo:**
```csharp
public interface ICartService
{
    Task<bool> AddToCartAsync(int productId, int quantity = 1);
    void RemoveFromCart(int productId);
    CartViewModel GetCart();
}

public class CartService : ICartService
{
    private readonly ApplicationDbContext _context;
    
    public CartService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // Implementación de la lógica de negocio...
}
```

**Registro en Program.cs:**
```csharp
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
```

### 6️⃣ **Data Layer (Capa de Datos)**
Gestiona el acceso a la base de datos mediante Entity Framework Core.

**Ubicación:** `Data/`

**Responsabilidades:**
- Contexto de base de datos (DbContext)
- Configuración de entidades
- Migraciones
- Datos iniciales (seed data)

---

## 🔄 Flujo de una Solicitud MVC

```
1. Usuario hace una solicitud HTTP
   ↓
2. ASP.NET Core Routing dirige la solicitud al Controller apropiado
   ↓
3. Controller recibe la solicitud
   ↓
4. Controller invoca el Service (lógica de negocio)
   ↓
5. Service interactúa con el Data Layer (DbContext)
   ↓
6. Service retorna datos al Controller
   ↓
7. Controller crea un ViewModel con los datos
   ↓
8. Controller selecciona una View y le pasa el ViewModel
   ↓
9. View renderiza HTML usando el ViewModel
   ↓
10. HTML se envía como respuesta al Usuario
```

---

## ✅ Principios Aplicados

### **Separation of Concerns (SoC)**
Cada capa tiene una responsabilidad específica y bien definida.

### **Dependency Injection (DI)**
Los servicios se inyectan en los controladores, promoviendo:
- Bajo acoplamiento
- Facilidad de testing
- Reutilización de código

### **Single Responsibility Principle (SRP)**
Cada clase tiene una única razón para cambiar.

### **Don't Repeat Yourself (DRY)**
La lógica de negocio está centralizada en servicios, evitando duplicación.

---

## 🔒 Seguridad Implementada

### **CSRF Protection**
- Uso de `[ValidateAntiForgeryToken]` en acciones POST
- Tokens anti-falsificación en formularios con `@Html.AntiForgeryToken()`

### **Input Validation**
- Data Annotations en modelos
- ModelState validation en controladores
- Validación de parámetros en servicios

### **SQL Injection Prevention**
- Uso de Entity Framework Core con consultas parametrizadas
- No se utiliza concatenación de strings en queries SQL

---

## 📊 Beneficios de esta Arquitectura

✅ **Mantenibilidad**: Código organizado y fácil de mantener  
✅ **Testabilidad**: Servicios e interfaces permiten unit testing  
✅ **Escalabilidad**: Fácil agregar nuevas funcionalidades  
✅ **Separación de Responsabilidades**: Cada capa tiene un propósito claro  
✅ **Reutilización**: Lógica de negocio centralizada en servicios  
✅ **Flexibilidad**: Fácil cambiar implementaciones (ej: cambiar ORM)  

---

## 🚀 Próximos Pasos

Para completar la arquitectura empresarial:

1. **Repository Pattern**: Abstraer acceso a datos
2. **Unit of Work**: Gestionar transacciones
3. **AutoMapper**: Mapeo automático entre entidades y ViewModels
4. **Logging**: Implementar Serilog para logging estructurado
5. **Exception Handling**: Middleware de manejo global de excepciones
6. **Validation Layer**: FluentValidation para validaciones complejas

---

## 📚 Referencias

- [ASP.NET Core MVC Overview](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview)
- [Dependency Injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
