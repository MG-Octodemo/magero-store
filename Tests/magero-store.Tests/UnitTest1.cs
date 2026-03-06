using AutoFixture;
using FluentAssertions;
using magero_store.Controllers;
using magero_store.Data;
using magero_store.Models;
using Microsoft.EntityFrameworkCore;

namespace magero_store.Tests;

/// <summary>
/// Tests para la funcionalidad de cálculo de totales del carrito - Issue #43
/// Siguiendo principios TDD: Red-Green-Refactor
/// </summary>
public class CartTotalCalculation_Issue43_Tests
{
    private readonly IFixture _fixture;

    public CartTotalCalculation_Issue43_Tests()
    {
        _fixture = new Fixture();
    }

    /// <summary>
    /// RED PHASE: Test que falla - El CartController debe calcular el subtotal para un solo producto
    /// </summary>
    [Fact]
    public void Should_CalculateSubtotal_When_CartHasSingleProduct_Issue43()
    {
        // Arrange - Configurar datos de prueba
        var product = _fixture.Build<Product>()
            .With(p => p.Id, 1)
            .With(p => p.Name, "Test Product")
            .With(p => p.Description, "Test Description")
            .With(p => p.Price, 10.50m)
            .With(p => p.ImageUrl, "test-url.jpg")
            .Create();

        var options = new DbContextOptionsBuilder<Data.ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new Data.ApplicationDbContext(options);
        context.Products.Add(product);
        context.SaveChanges();

        var controller = new CartController(context);
        var cartItems = new List<CartItem>
        {
            new CartItem { ProductId = 1, Product = product, Quantity = 2 }
        };

        // Act - Ejecutar el método que debería calcular el subtotal
        // NOTA: Este método NO existe aún - debe fallar con método no encontrado
        var result = controller.CalculateSubtotal(cartItems);

        // Assert - Verificar el resultado esperado
        result.Should().Be(21.00m, "porque 2 productos a $10.50 cada uno = $21.00");
    }
}