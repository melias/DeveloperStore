namespace SalesApi.Domain.Entities;

public class SaleItem
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Discount { get; private set; }
    public decimal Total { get; private set; }
    public Guid SaleId { get; private set; }

    public SaleItem(Guid productId, int quantity, decimal unitPrice)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = CalculateTax();
        Total = (UnitPrice * Quantity) - Discount;
    }

    private decimal CalculateTax()
    {
        if (Quantity < 4) return 0;
        if (Quantity >= 10 && Quantity <= 20) return UnitPrice * Quantity * 0.20m;
        if (Quantity > 20) throw new InvalidOperationException("You can buy only 20 pices of a item.");
        return UnitPrice * Quantity * 0.10m;
    }

    private SaleItem() { }
}
