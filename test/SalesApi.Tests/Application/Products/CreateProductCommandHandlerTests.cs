using NSubstitute;
using SalesApi.Application.DTOs;
using SalesApi.Application.Products;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Interfaces;
using Xunit;

namespace SalesApi.Tests.Application.Products;

public class CreateProductCommandHandlerTests
{
    private readonly IProductRepository _repo = Substitute.For<IProductRepository>();
    private readonly CreateProductCommandHandler _handler;

    public CreateProductCommandHandlerTests()
    {
        _handler = new CreateProductCommandHandler(_repo);
    }

    [Fact]
    public async Task Handle_ShouldCreateProduct()
    {
        var dto = new ProductRequestDto("Test", "desc", 100, "cat", "img");

        var command = new CreateProductCommand(dto);
        var result = await _handler.Handle(command, CancellationToken.None);

        await _repo.Received(1).AddAsync(Arg.Is<Product>(p =>
            p.Title == dto.Title&&
            p.Description == dto.Description &&
            p.Price == dto.Price &&
            p.Category == dto.Category));

        await _repo.Received(1).SaveChangesAsync();

        Assert.NotNull(result);
        Assert.Equal(dto.Title, result.Title);
    }
}
