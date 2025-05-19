using MediatR;
using SalesApi.Application.DTOs;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Interfaces;

namespace SalesApi.Application.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponseDto>
{
    private readonly IProductRepository _repo;

    public CreateProductCommandHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Product;
        var product = new Product(dto.Title, dto.Description, dto.Price, dto.Category, dto.Image);

        await _repo.AddAsync(product);
        await _repo.SaveChangesAsync();

        return new ProductResponseDto(product.Id, product.Title, product.Description, product.Price, product.Category, product.Image);
    }
}
