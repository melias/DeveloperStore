using SalesApi.Application.DTOs;

namespace SalesApi.Application.Services;

public interface ISaleService
{
    Task<SaleResponseDto> CreateAsync(SaleRequestDto dto);
    Task<IEnumerable<SaleResponseDto>> GetAllAsync();
    Task CancelAsync(Guid id);
}
