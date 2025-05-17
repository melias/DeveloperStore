using SalesApi.Application.DTOs;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Interfaces;

namespace SalesApi.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
    {
        var products = await _repo.GetAllAsync();
        return products.Select(p => new ProductResponseDto(p.Id, p.Title, p.Description, p.Price, p.Category, p.Image));
    }

    public async Task<ProductResponseDto> CreateAsync(ProductRequestDto dto)
    {
        var product = new Product(dto.Title, dto.Description, dto.Price, dto.Category, dto.Image);
        await _repo.AddAsync(product);
        await _repo.SaveChangesAsync();

        return new ProductResponseDto(product.Id, product.Title, product.Description, product.Price, product.Category, product.Image);
    }
}
