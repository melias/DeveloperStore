using SalesApi.Application.DTOs;

namespace SalesApi.Application;

public class ProductResponse
{
    public List<ProductResponseDto>? Data { get; set; }
    public required string Status { get; set; }
    public required string Message { get; set; }
}
