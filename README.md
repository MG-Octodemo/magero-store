# magero-store

## Overview
magero-store is a sample e-commerce application built using .NET Core MVC. The application simulates a shopping experience similar to popular e-commerce platforms, allowing users to browse products, add items to their cart, and complete purchases.

## ✨ Recent Updates (Fase 1 - Consolidación y Optimización)

### Completed Improvements
- ✅ **Code Consolidation**: Removed duplicate `ApplicationDbContext` and obsolete `Startup.cs`
- ✅ **Model Validations**: Added robust validation attributes to `Product` and `CartItem` models
- ✅ **CSRF Protection**: Implemented anti-forgery tokens in all POST forms
- ✅ **Nullable Types**: Resolved all nullable reference type warnings (0 build warnings)
- ✅ **Database Migrations**: Created initial migration with seed data

For detailed information about Phase 1 changes, see [CAMBIOS_FASE1.md](CAMBIOS_FASE1.md).

## Features
- **Home Page**: Displays featured products and navigation options.
- **Product Listing**: Users can view all available products and filter through them.
- **Product Details**: Detailed view of each product, including descriptions and images.
- **Shopping Cart**: Users can view items added to their cart and adjust quantities.
- **Checkout Process**: A streamlined process for users to finalize their purchases.
- **Security**: CSRF protection on all form submissions.
- **Data Validation**: Server-side validation for products and cart items.

## Project Structure
```
magero-store
├── Controllers
│   ├── HomeController.cs
│   ├── ProductsController.cs
│   └── CartController.cs (with CSRF protection)
├── Data
│   ├── ApplicationDbContext.cs (with seed data)
│   └── SampleData.cs
├── Models
│   ├── Product.cs (with validations)
│   └── CartItem.cs (with validations)
├── Migrations
│   └── [timestamp]_InitialCreate.cs
├── Views
│   ├── Home
│   │   └── Index.cshtml
│   ├── Products
│   │   ├── Index.cshtml (with anti-forgery tokens)
│   │   └── Details.cshtml (with anti-forgery tokens)
│   ├── Cart
│   │   ├── Index.cshtml (with anti-forgery tokens)
│   │   └── Checkout.cshtml (with anti-forgery tokens)
│   └── Shared
│       ├── _Layout.cshtml
│       └── _ViewImports.cshtml
├── wwwroot
│   ├── css
│   │   └── site.css
│   ├── js
│   │   └── site.js
│   └── lib
├── appsettings.json
├── Program.cs
├── CAMBIOS_FASE1.md
└── README.md
```

## Getting Started

### Prerequisites
- .NET 8.0 SDK or later
- SQLite (included with .NET)

### Setup Instructions

1. **Clone the Repository**: 
   ```bash
   git clone <repository-url>
   cd magero-store
   ```

2. **Install Dependencies**: 
   ```bash
   dotnet restore
   ```

3. **Apply Database Migrations**:
   ```bash
   dotnet ef database update
   ```
   This will create the SQLite database with seed data (5 sample products).

4. **Run the Application**: 
   ```bash
   dotnet run
   ```
   Navigate to `http://localhost:5000` in your web browser to view the application.

## Development

### Building the Project
```bash
dotnet build
```

### Running Tests
Tests will be added in future phases.

### Database Commands
```bash
# Create a new migration
dotnet ef migrations add [MigrationName]

# Apply migrations
dotnet ef database update

# Remove last migration (if not applied)
dotnet ef migrations remove
```

## Security Features

- **CSRF Protection**: All POST forms include anti-forgery tokens
- **Model Validation**: Server-side validation for all data inputs
- **Input Sanitization**: Data annotations ensure data integrity

## Roadmap

### ✅ Phase 1: Consolidation and Optimization (Completed)
- Code cleanup and duplicate removal
- Model validations and security
- CSRF protection
- Database migrations

### 🔄 Phase 2: Core Functionality (Planned)
- ASP.NET Core Identity authentication system
- Order management system
- Complete checkout flow

### 📋 Phase 3: Advanced Features (Planned)
- Admin panel with dashboard
- REST API with Swagger documentation
- JWT authentication

### 🚀 Phase 4: Optimization and Production (Planned)
- Caching strategies
- Production configuration
- Docker containerization

## Contributing
Contributions are welcome! Please feel free to submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License - see the LICENSE file for details.