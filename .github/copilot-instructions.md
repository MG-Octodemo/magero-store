# Magero Store - AI Coding Instructions

## Architecture Overview
This is an ASP.NET Core 9.0 MVC e-commerce application with a hybrid data access pattern:
- **Primary**: Entity Framework Core with SQLite (`ApplicationDbContext` in `Data/`)
- **Secondary**: Dapper for raw SQL queries in `ProductsController.Search()` 
- **Session-based cart**: Uses `SessionExtensions` helper for cart persistence (no auth system)
- **Dual data sources**: EF seeded data + static `SampleData.Products` list

## Key Conventions

### Documentation & Language
- **Documentation**: Generate XML docs in Spanish following existing pattern in `Models/Product.cs`
- **Comments**: Use Spanish for business logic, English for technical implementation
- **Validation**: Always validate parameters and connections at method start (see `CartController`)

### Data Access Patterns
- **Controllers**: Direct EF context injection (see `CartController._context`)
- **Search**: Uses Dapper with parameterized queries in `ProductsController.Search()`
- **Cart**: Session-based using `SessionExtensions.Set<T>()` and `Get<T>()`
- **Models**: Simple POCOs with data annotations for validation

### Project Structure Quirks
- **Namespace**: Uses underscores (`magero_store`) not hyphens
- **Multiple view folders**: `Views/Products/`, `Views/Product/`, `Views/Productos/` exist - use `Products/`
- **Empty services**: `Services/ProductFilterService.cs` exists but empty - implement here for filtering logic
- **Mixed data**: EF seeded data in `ApplicationDbContext` + static data in `SampleData`

## Critical Workflows

### Running the Application
```bash
dotnet run                    # Uses SQLite, auto-creates DB from migrations
# Access at https://localhost:5001 or http://localhost:5000
```

### Adding New Products
1. Add to `Data/SampleData.Products` for immediate testing
2. Add EF migration for persistent storage: `dotnet ef migrations add ProductUpdate`
3. Update both if product model changes

### Cart Operations
- Uses session storage (no database persistence)
- Cart data survives page refreshes but not browser restarts
- Helper methods in `CartController`: `GetCartItems()`, `AddOrUpdateCartItem()`

## Integration Points

### Database
- **Connection**: SQLite file `magerostore.db` (see `appsettings.json`)
- **Seeding**: Automatic via `ApplicationDbContext.OnModelCreating()`
- **Development**: Database recreated on each migration

### Session Management
- **Timeout**: 30 minutes idle (configured in `Program.cs`)
- **Required**: For cart functionality - ensure `app.UseSession()` called
- **Serialization**: Uses `System.Text.Json` in `SessionExtensions`

### External Dependencies
- **Images**: Unsplash URLs for product images (may break in offline environments)
- **UI**: Bootstrap 5 classes in views (loaded via CDN in `_Layout.cshtml`)

## Code Reuse Patterns
- **Session helpers**: Use `SessionExtensions.Set<T>()` and `Get<T>()` for all session data
- **View models**: Create in `ViewModels/` folder for complex views
- **Static data**: Extend `SampleData` class for test data across controllers
- **Error handling**: Follow pattern in `ProductsController.Details()` - return `NotFound()` for missing resources

## Security Notes
- **No authentication**: Application has no user system (session-based cart only)
- **SQL injection**: `ProductsController.Search()` demonstrates parameterized queries with Dapper
- **CSRF**: No anti-forgery tokens implemented - add `[ValidateAntiForgeryToken]` for POST actions

## Testing & Debugging
- **Test data**: Use `SampleData.Products` for consistent test scenarios
- **Database reset**: Delete `magerostore.db` file to reset all data
- **Session debugging**: Check browser dev tools → Application → Cookies for session data