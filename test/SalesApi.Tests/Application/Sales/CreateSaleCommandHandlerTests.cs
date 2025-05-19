using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using SalesApi.Application.DTOs;
using SalesApi.Application.Sales;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Interfaces;
using Xunit;

namespace SalesApi.Tests.Application.Sales;

public class CreateSaleCommandHandlerTests
{
    private readonly ISaleRepository _repository;
    private readonly CreateSaleCommandHandler _handler;

    public CreateSaleCommandHandlerTests()
    {
        _repository = Substitute.For<ISaleRepository>();
        _handler = new CreateSaleCommandHandler(_repository);
    }

    [Fact]
    public async Task Handle_ShouldCreateSaleCorrectly()
    {
        // Arrange
        var dto = new SaleRequestDto(
            SaleNumber: "1234",
            SaleDate: DateTime.UtcNow,
            CustomerId: Guid.NewGuid(),
            BranchId: Guid.NewGuid(),
            Items: new List<SaleItemRequestDto>
            {
                new(Guid.NewGuid(), 2, 10m),
                new(Guid.NewGuid(), 5, 5m)
            });

        var command = new CreateSaleCommand(dto);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _repository.Received(1).AddAsync(Arg.Is<Sale>(s =>
            s.SaleNumber == dto.SaleNumber &&
            s.CustomerId == dto.CustomerId &&
            s.BranchId == dto.BranchId &&
            s.Items.Count == 2));

        await _repository.Received(1).SaveChangesAsync();

        Assert.NotNull(result);
        Assert.Equal(dto.SaleNumber, result.SaleNumber);
        Assert.Equal(2, result.Items.Count);
    }
}
