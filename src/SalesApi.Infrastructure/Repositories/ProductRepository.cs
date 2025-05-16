using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Interfaces;

namespace SalesApi.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly SalesDbContext _context;

    public ProductRepository(SalesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _context.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(Guid id) =>
        await _context.Products.FindAsync(id);

    public async Task AddAsync(Product product) =>
        await _context.Products.AddAsync(product);

    public async Task DeleteAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is not null)
            _context.Products.Remove(product);
    }

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
