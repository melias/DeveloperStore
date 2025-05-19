using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Entities;

namespace SalesApi.Infrastructure;

public class SalesDbContext : DbContext
{
    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleItem> SaleItems => Set<SaleItem>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products"); 
            entity.HasKey(p => p.Id);
        });

        modelBuilder.Entity<Sale>(builder =>
        {
            builder.ToTable("sales");
            builder.HasKey(s => s.Id);
            builder.HasMany(s => s.Items).WithOne().HasForeignKey(i => i.SaleId);
        });

        modelBuilder.Entity<SaleItem>(builder =>
        {
            builder.ToTable("sale_items");
            builder.HasKey(i => i.Id);
        });
    }
}