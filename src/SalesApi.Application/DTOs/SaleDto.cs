namespace SalesApi.Application.DTOs;

public record SaleItemRequestDto(Guid ProductId, int Quantity, decimal UnitPrice);

public record SaleRequestDto(
    string SaleNumber,
    DateTime SaleDate,
    Guid CustomerId,
    Guid BranchId,
    List<SaleItemRequestDto> Items
);

public record SaleItemResponseDto(
    Guid Id,
    Guid ProductId,
    int Quantity,
    decimal UnitPrice,
    decimal Discount,
    decimal Total,
    Guid SaleId
);

public record SaleResponseDto(
    Guid Id,
    string SaleNumber,
    DateTime Date,
    Guid CustomerId,
    Guid BranchId,
    decimal TotalAmount,
    bool Cancelled,
    List<SaleItemResponseDto> Items
);
