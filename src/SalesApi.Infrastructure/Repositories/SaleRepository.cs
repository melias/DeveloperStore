using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Interfaces;

namespace SalesApi.Infrastructure.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly SalesDbContext _context;

    public SaleRepository(SalesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Sale>> GetAllAsync() =>
        await _context.Sales.Include(s => s.Items).ToListAsync();

    public async Task<Sale?> GetByIdAsync(Guid id) =>
        await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id);

    public async Task AddAsync(Sale sale) =>
        await _context.Sales.AddAsync(sale);

    public async Task DeleteAsync(Guid id)
    {
        var sale = await _context.Sales.FindAsync(id);
        if (sale != null) sale.Cancel();
    }

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
