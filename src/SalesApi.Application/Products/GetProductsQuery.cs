using MediatR;
using SalesApi.Application.DTOs;

namespace SalesApi.Application.Products;

public record GetProductsQuery : IRequest<IEnumerable<ProductResponseDto>>;
