namespace SalesApi.Domain.Entities;

public class SaleItem
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal ValueMonetaryTaxApplied { get; private set; }
    public decimal Total { get; private set; }
    public Guid SaleId { get; private set; }

    public SaleItem(Guid productId, int quantity, decimal unitPrice)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        ValueMonetaryTaxApplied = CalculateTax();
        Total = (UnitPrice * Quantity) + ValueMonetaryTaxApplied;
    }

    private decimal CalculateTax()
    {
        if (Quantity < 4) return 0;
        if (Quantity > 20) throw new InvalidOperationException("You cannot buy more than 20 pieces of the same item.");
        if (Quantity >= 10) return UnitPrice * Quantity * 0.20m; // IVA ESPECIAL
        return UnitPrice * Quantity * 0.10m; // IVA
    }

    private SaleItem() { }
}
