using MediatR;
using SalesApi.Application.DTOs;

namespace SalesApi.Application.Products;

public record CreateProductCommand(ProductRequestDto Product) : IRequest<ProductResponseDto>;
