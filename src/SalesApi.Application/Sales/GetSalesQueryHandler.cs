using MediatR;
using SalesApi.Domain.Interfaces;
using SalesApi.Application.DTOs;

namespace SalesApi.Application.Sales;

public class GetSalesQueryHandler : IRequestHandler<GetSalesQuery, IEnumerable<SaleResponseDto>>
{
    private readonly ISaleRepository _repo;

    public GetSalesQueryHandler(ISaleRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<SaleResponseDto>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
    {
        var sales = await _repo.GetAllAsync();

        return sales.Select(sale => new SaleResponseDto(
            sale.Id, sale.SaleNumber, sale.Date, sale.CustomerId, sale.BranchId,
            sale.TotalAmount, sale.Cancelled,
            sale.Items.Select(i => new SaleItemResponseDto(
                i.Id, i.ProductId, i.Quantity, i.UnitPrice, i.Discount, i.Total, i.SaleId)).ToList()
        ));
    }
}
