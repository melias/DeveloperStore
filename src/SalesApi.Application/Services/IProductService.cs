using SalesApi.Application.DTOs;

namespace SalesApi.Application.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponseDto>> GetAllAsync();
    Task<ProductResponseDto> CreateAsync(ProductRequestDto dto);
}