using MediatR;
using SalesApi.Application.DTOs;

namespace SalesApi.Application.Sales;

public record CreateSaleCommand(SaleRequestDto Sale) : IRequest<SaleResponseDto>;
