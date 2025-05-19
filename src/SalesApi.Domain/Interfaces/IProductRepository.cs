using SalesApi.Domain.Entities;

namespace SalesApi.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}
