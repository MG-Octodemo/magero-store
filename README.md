# Magero Store 🛒

## 📋 Overview
**Magero Store** es una aplicación de e-commerce profesional desarrollada con **ASP.NET Core MVC** que implementa las mejores prácticas de arquitectura de software empresarial. La aplicación simula una experiencia completa de compra en línea con gestión de productos, carrito de compras y proceso de checkout.

## ✨ Características Principales

### 🛍️ Funcionalidades Implementadas
- ✅ **Catálogo de Productos**: Navegación y búsqueda de productos
- ✅ **Detalles de Producto**: Vista detallada con información completa
- ✅ **Carrito de Compras**: Gestión completa de items con cálculos automáticos
- ✅ **Proceso de Checkout**: Formulario completo con validaciones
- ✅ **Búsqueda de Productos**: Sistema de búsqueda seguro y eficiente

### 🏗️ Arquitectura MVC Empresarial
- ✅ **Patrón MVC**: Implementación completa del patrón Model-View-Controller
- ✅ **Capa de Servicios**: Lógica de negocio separada y reutilizable
- ✅ **ViewModels**: Modelos de presentación optimizados
- ✅ **Inyección de Dependencias**: Arquitectura desacoplada y testeable
- ✅ **Entity Framework Core**: ORM con consultas seguras y parametrizadas

### 🔒 Seguridad
- ✅ **Protección CSRF**: Tokens anti-falsificación en formularios
- ✅ **Prevención SQL Injection**: Consultas parametrizadas con EF Core
- ✅ **Validaciones Multicapa**: Validaciones en Model, ViewModel y Service
- ✅ **Data Annotations**: Validaciones completas en entidades

## 🎯 Arquitectura del Proyecto

### Estructura de Carpetas
```
magero-store/
├── Controllers/              # Controladores MVC (Capa de presentación)
│   ├── HomeController.cs     # Controlador principal
│   ├── ProductsController.cs # Gestión de productos
│   └── CartController.cs     # Gestión del carrito
│
├── Services/                 # Capa de Servicios (Lógica de negocio)
│   ├── IProductService.cs    # Interface de productos
│   ├── ProductService.cs     # Implementación de productos
│   ├── ICartService.cs       # Interface de carrito
│   └── CartService.cs        # Implementación de carrito
│
├── Models/                   # Modelos de Dominio (Entidades)
│   ├── Product.cs           # Entidad Producto
│   └── CartItem.cs          # Entidad Item del Carrito
│
├── ViewModels/              # ViewModels (Modelos de presentación)
│   ├── ProductViewModel.cs  # ViewModel de producto
│   ├── CartViewModel.cs     # ViewModel del carrito
│   ├── CartItemViewModel.cs # ViewModel de item
│   └── CheckoutViewModel.cs # ViewModel de checkout
│
├── Views/                   # Vistas Razor (UI)
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Products/
│   │   ├── Index.cshtml
│   │   └── Details.cshtml
│   ├── Cart/
│   │   ├── Index.cshtml
│   │   └── Checkout.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       └── _ViewImports.cshtml
│
├── Data/                    # Capa de Acceso a Datos
│   ├── ApplicationDbContext.cs  # Contexto EF Core
│   └── SampleData.cs       # Datos de ejemplo
│
├── wwwroot/                # Archivos estáticos
│   ├── css/
│   ├── js/
│   └── lib/
│
├── ARQUITECTURA_MVC.md     # 📚 Documentación detallada de arquitectura
├── DIAGRAMA_ARQUITECTURA.md # 📊 Diagramas visuales de arquitectura
├── Program.cs              # Punto de entrada y configuración DI
└── appsettings.json        # Configuración de la aplicación
```

## 🚀 Tecnologías Utilizadas

- **Framework**: ASP.NET Core 8.0 MVC
- **Lenguaje**: C# 12
- **ORM**: Entity Framework Core 7.0
- **Base de Datos**: SQLite (desarrollo) / SQL Server (producción)
- **Frontend**: Razor Pages, Bootstrap 5.2, jQuery
- **Patrones**: MVC, Repository Pattern, Dependency Injection, Service Layer
- **Seguridad**: Anti-CSRF Tokens, Data Annotations, Parametrized Queries

## 🏛️ Principios de Diseño

### Implementación de SOLID
- ✅ **Single Responsibility**: Cada clase tiene una única responsabilidad
- ✅ **Open/Closed**: Código abierto para extensión, cerrado para modificación
- ✅ **Liskov Substitution**: Interfaces e implementaciones intercambiables
- ✅ **Interface Segregation**: Interfaces específicas y cohesivas
- ✅ **Dependency Inversion**: Dependencia de abstracciones, no implementaciones

### Separation of Concerns
- **Controllers**: Solo manejan HTTP requests y responses
- **Services**: Contienen toda la lógica de negocio
- **ViewModels**: Modelos optimizados para presentación
- **Models**: Entidades de dominio con validaciones
- **Views**: Solo presentación, sin lógica de negocio

## 📦 Instalación y Configuración

### Prerrequisitos
- .NET 8.0 SDK o superior
- Visual Studio 2022 / VS Code / Rider
- SQLite (incluido) o SQL Server

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/MG-Octodemo/magero-store.git
   cd magero-store
   ```

2. **Restaurar dependencias**
   ```bash
   dotnet restore
   ```

3. **Aplicar migraciones de base de datos**
   ```bash
   dotnet ef database update
   ```
   > Nota: La base de datos SQLite se creará automáticamente con datos de ejemplo

4. **Compilar el proyecto**
   ```bash
   dotnet build
   ```

5. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```
   
6. **Abrir en el navegador**
   ```
   https://localhost:5001
   o
   http://localhost:5000
   ```

## 🧪 Testing

```bash
# Ejecutar todos los tests
dotnet test

# Ejecutar con cobertura
dotnet test /p:CollectCoverage=true
```

## 📚 Documentación

### Documentación Técnica
- 📖 [ARQUITECTURA_MVC.md](ARQUITECTURA_MVC.md) - Explicación detallada de la arquitectura
- 📊 [DIAGRAMA_ARQUITECTURA.md](DIAGRAMA_ARQUITECTURA.md) - Diagramas visuales del sistema

### Flujo de Datos
```
Usuario → Controller → Service → Data Layer → Database
                ↓
            ViewModel
                ↓
              View → HTML Response
```

## 🔐 Seguridad

La aplicación implementa múltiples capas de seguridad:

1. **Protección CSRF**: Tokens en todos los formularios POST
2. **Validación de Entrada**: Data Annotations y ModelState
3. **SQL Injection**: Prevención mediante EF Core parametrizado
4. **XSS Protection**: Tag Helpers con auto-escape de HTML
5. **HTTPS**: Redirección automática en producción

## 🎨 Características del Código

- ✅ **0 Warnings** en compilación
- ✅ **Documentación XML** completa en español
- ✅ **Código limpio** siguiendo convenciones de C#
- ✅ **Dependency Injection** en toda la aplicación
- ✅ **Async/Await** para operaciones I/O
- ✅ **Manejo de errores** robusto

## 🌟 Mejores Prácticas Implementadas

1. **Separation of Concerns**: Cada capa tiene responsabilidad única
2. **DRY (Don't Repeat Yourself)**: Lógica centralizada en servicios
3. **KISS (Keep It Simple)**: Código claro y fácil de entender
4. **YAGNI**: Solo lo necesario, sin sobre-ingeniería
5. **Dependency Injection**: Bajo acoplamiento, alta cohesión
6. **Repository Pattern**: Abstracción del acceso a datos
7. **ViewModel Pattern**: Separación entre dominio y presentación

## 📈 Roadmap Futuro

### Fase 2: Autenticación y Autorización
- [ ] ASP.NET Core Identity
- [ ] Roles: Admin, Customer
- [ ] Login/Register
- [ ] Gestión de usuarios

### Fase 3: Gestión de Pedidos
- [ ] Modelo Order y OrderItem
- [ ] Tracking de pedidos
- [ ] Estados de pedido
- [ ] Historial de compras

### Fase 4: Panel de Administración
- [ ] Área de administración (Areas/Admin)
- [ ] Dashboard con métricas
- [ ] CRUD completo de productos
- [ ] Gestión de pedidos
- [ ] Reportes de ventas

### Fase 5: API y Optimización
- [ ] Web API REST
- [ ] Documentación Swagger
- [ ] JWT Authentication
- [ ] Caching estratégico
- [ ] Performance optimization

## 🤝 Contribución

Las contribuciones son bienvenidas. Por favor:

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add: Amazing Feature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📝 Convenciones de Código

- **Idioma**: Código y documentación en español
- **Nomenclatura**: PascalCase para clases y métodos públicos
- **Comentarios**: Documentación XML en todos los métodos públicos
- **Estilo**: Seguir guías de estilo de C# y ASP.NET Core

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.

## 👥 Autores

- **Magero Team** - *Desarrollo inicial* - [MG-Octodemo](https://github.com/MG-Octodemo)

## 🙏 Agradecimientos

- ASP.NET Core Team por el excelente framework
- Entity Framework Core por el ORM robusto
- Bootstrap por los componentes UI
- Comunidad de desarrolladores .NET

---

⭐ **Si te ha gustado este proyecto, no olvides darle una estrella en GitHub!**
├── appsettings.json
├── Program.cs
├── Startup.cs
└── README.md
```

## Getting Started
1. **Clone the Repository**: 
   ```
   git clone <repository-url>
   cd magero-store
   ```

2. **Install Dependencies**: 
   Ensure you have the .NET Core SDK installed. Run the following command to restore dependencies:
   ```
   dotnet restore
   ```

3. **Run the Application**: 
   Start the application using:
   ```
   dotnet run
   ```
   Navigate to `http://localhost:5000` in your web browser to view the application.

## Contributing
Contributions are welcome! Please feel free to submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License - see the LICENSE file for details.