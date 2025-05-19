using NSubstitute;
using SalesApi.Application.Sales;
using SalesApi.Domain.Interfaces;
using Xunit;

namespace SalesApi.Tests.Application.Sales;

public class CancelSaleCommandHandlerTests
{
    private readonly ISaleRepository _repo = Substitute.For<ISaleRepository>();
    private readonly CancelSaleCommandHandler _handler;

    public CancelSaleCommandHandlerTests()
    {
        _handler = new CancelSaleCommandHandler(_repo);
    }

    [Fact]
    public async Task Handle_ShouldCancelSale()
    {
        var saleId = Guid.NewGuid();

        var command = new CancelSaleCommand(saleId);
        await _handler.Handle(command, CancellationToken.None);

        await _repo.Received(1).DeleteAsync(saleId);
        await _repo.Received(1).SaveChangesAsync();
    }
}
