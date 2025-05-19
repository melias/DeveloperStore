using NSubstitute;
using SalesApi.Application.Products;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Interfaces;
using Xunit;

namespace SalesApi.Tests.Application.Products;

public class GetProductsQueryHandlerTests
{
    private readonly IProductRepository _repo = Substitute.For<IProductRepository>();
    private readonly GetProductsQueryHandler _handler;

    public GetProductsQueryHandlerTests()
    {
        _handler = new GetProductsQueryHandler(_repo);
    }

    [Fact]
    public async Task Handle_ShouldReturnProductList()
    {
        var fakeProducts = new List<Product>
        {
            new("P1", "Desc1", 10, "Cat", "Img"),
            new("P2", "Desc2", 20, "Cat", "Img")
        };

        _repo.GetAllAsync().Returns(fakeProducts);

        var result = await _handler.Handle(new GetProductsQuery(), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        await _repo.Received(1).GetAllAsync();
    }
}
