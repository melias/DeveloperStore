using NSubstitute;
using SalesApi.Application.Sales;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Interfaces;
using Xunit;

namespace SalesApi.Tests.Application.Sales;

public class GetSalesQueryHandlerTests
{
    private readonly ISaleRepository _repo = Substitute.For<ISaleRepository>();
    private readonly GetSalesQueryHandler _handler;

    public GetSalesQueryHandlerTests()
    {
        _handler = new GetSalesQueryHandler(_repo);
    }

    [Fact]
    public async Task Handle_ShouldReturnListOfSales()
    {
        var fakeSales = new List<Sale>
        {
            new("S1", DateTime.UtcNow, Guid.NewGuid(), Guid.NewGuid()),
            new("S2", DateTime.UtcNow, Guid.NewGuid(), Guid.NewGuid())
        };

        _repo.GetAllAsync().Returns(fakeSales);

        var result = await _handler.Handle(new GetSalesQuery(), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        await _repo.Received(1).GetAllAsync();
    }
}
