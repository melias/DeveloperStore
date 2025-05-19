using SalesApi.Application.DTOs;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Interfaces;

namespace SalesApi.Application.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _repo;

    public SaleService(ISaleRepository repo)
    {
        _repo = repo;
    }

    public async Task<SaleResponseDto> CreateAsync(SaleRequestDto dto)
    {
        var sale = new Sale(dto.SaleNumber, dto.SaleDate, dto.CustomerId, dto.BranchId);

        foreach (var item in dto.Items)
        {
            var saleItem = new SaleItem(item.ProductId, item.Quantity, item.UnitPrice);
            sale.AddItem(saleItem);
        }

        await _repo.AddAsync(sale);
        await _repo.SaveChangesAsync();

        return MapToResponse(sale);
    }

    public async Task<IEnumerable<SaleResponseDto>> GetAllAsync()
    {
        var sales = await _repo.GetAllAsync();
        return sales.Select(MapToResponse);
    }

    public async Task CancelAsync(Guid id)
    {
        await _repo.DeleteAsync(id);
        await _repo.SaveChangesAsync();
    }

    private static SaleResponseDto MapToResponse(Sale sale)
    {
        return new SaleResponseDto(
            sale.Id,
            sale.SaleNumber,
            sale.Date,
            sale.CustomerId,
            sale.BranchId,
            sale.TotalAmount,
            sale.Cancelled,
            sale.Items.Select(i => new SaleItemResponseDto(
                i.Id,
                i.ProductId,
                i.Quantity,
                i.UnitPrice,
                i.Discount,
                i.Total,
                i.SaleId
            )).ToList()
        );
    }
}
