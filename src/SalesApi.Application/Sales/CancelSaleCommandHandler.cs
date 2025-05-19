using MediatR;
using SalesApi.Domain.Interfaces;

namespace SalesApi.Application.Sales;

public class CancelSaleCommandHandler : IRequestHandler<CancelSaleCommand>
{
    private readonly ISaleRepository _repo;

    public CancelSaleCommandHandler(ISaleRepository repo)
    {
        _repo = repo;
    }

    public async Task Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {
        await _repo.DeleteAsync(request.SaleId);
        await _repo.SaveChangesAsync();
    }
}
