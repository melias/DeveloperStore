using MediatR;
using SalesApi.Application.DTOs;

namespace SalesApi.Application.Sales;

public record GetSalesQuery : IRequest<IEnumerable<SaleResponseDto>>;
