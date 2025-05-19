using MediatR;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Interfaces;
using SalesApi.Application.DTOs;

namespace SalesApi.Application.Sales;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, SaleResponseDto>
{
    private readonly ISaleRepository _repo;

    public CreateSaleCommandHandler(ISaleRepository repo)
    {
        _repo = repo;
    }

    public async Task<SaleResponseDto> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Sale;
        var sale = new Sale(dto.SaleNumber, dto.SaleDate, dto.CustomerId, dto.BranchId);

        foreach (var item in dto.Items)
        {
            var saleItem = new SaleItem(item.ProductId, item.Quantity, item.UnitPrice);
            sale.AddItem(saleItem);
        }

        await _repo.AddAsync(sale);
        await _repo.SaveChangesAsync();

        return new SaleResponseDto(
            sale.Id, sale.SaleNumber, sale.Date, sale.CustomerId, sale.BranchId,
            sale.TotalAmount, sale.Cancelled,
            sale.Items.Select(i => new SaleItemResponseDto(
                i.Id, i.ProductId, i.Quantity, i.UnitPrice, i.Discount, i.Total, i.SaleId)).ToList()
        );
    }
}
