using SalesApi.Domain.Entities;
using Xunit;

namespace SalesApi.Tests.Domain;

public class SaleItemTests
{
    [Theory]
    [InlineData(1, 100, 0)]
    [InlineData(3, 100, 0)]
    public void Should_Have_Zero_Tax_When_Less_Than_4(int quantity, decimal unitPrice, decimal expectedTax)
    {
        var item = new SaleItem(Guid.NewGuid(), quantity, unitPrice);

        Assert.Equal(expectedTax, item.ValueMonetaryTaxApplied);
        Assert.Equal((quantity * unitPrice) + expectedTax, item.Total);
    }

    [Theory]
    [InlineData(4, 100, 40)]
    [InlineData(9, 100, 90)]
    public void Should_Apply_IVA_When_Quantity_Between_4_And_9(int quantity, decimal unitPrice, decimal expectedTax)
    {
        var item = new SaleItem(Guid.NewGuid(), quantity, unitPrice);

        Assert.Equal(expectedTax, item.ValueMonetaryTaxApplied);
        Assert.Equal((quantity * unitPrice) + expectedTax, item.Total);
    }

    [Theory]
    [InlineData(10, 100, 200)]
    [InlineData(20, 100, 400)]
    public void Should_Apply_Special_Tax_When_Quantity_Between_10_And_20(int quantity, decimal unitPrice, decimal expectedTax)
    {
        var item = new SaleItem(Guid.NewGuid(), quantity, unitPrice);

        Assert.Equal(expectedTax, item.ValueMonetaryTaxApplied);
        Assert.Equal((quantity * unitPrice) + expectedTax, item.Total);
    }

    [Fact]
    public void Should_Throw_When_Quantity_Exceeds_20()
    {
        var productId = Guid.NewGuid();
        var quantity = 21;
        var unitPrice = 100m;

        var ex = Assert.Throws<InvalidOperationException>(() =>
            new SaleItem(productId, quantity, unitPrice));

        Assert.Equal("You cannot buy more than 20 pieces of the same item.", ex.Message);
    }
}
