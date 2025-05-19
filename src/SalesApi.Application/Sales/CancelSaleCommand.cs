using MediatR;

namespace SalesApi.Application.Sales;

public record CancelSaleCommand(Guid SaleId) : IRequest;
