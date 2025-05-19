using SalesApi.Domain.Entities;

namespace SalesApi.Domain.Interfaces;

public interface ISaleRepository
{
    Task<IEnumerable<Sale>> GetAllAsync();
    Task<Sale?> GetByIdAsync(Guid id);
    Task AddAsync(Sale sale);
    Task DeleteAsync(Guid id); // Cancelamento
    Task SaveChangesAsync();
}
