using SalesApi.Application.DTOs;

namespace SalesApi.Application;

public class SalesResponse
{
    public List<SaleResponseDto>? Data { get; set; }
    public required string Status { get; set; }
    public required string Message { get; set; }
}
