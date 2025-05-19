using MediatR;
using SalesApi.Domain.Interfaces;
using SalesApi.Application.DTOs;

namespace SalesApi.Application.Products;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductResponseDto>>
{
    private readonly IProductRepository _repo;

    public GetProductsQueryHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<ProductResponseDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repo.GetAllAsync();
        return products.Select(p => new ProductResponseDto(p.Id, p.Title, p.Description, p.Price, p.Category, p.Image));
    }
}
