namespace SalesApi.Domain.Entities;

public class Sale
{
    public Guid Id { get; private set; }
    public string SaleNumber { get; private set; } = null!;
    public DateTime Date { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid BranchId { get; private set; }
    public decimal TotalAmount { get; private set; }
    public bool Cancelled { get; private set; }

    public List<SaleItem> Items { get; private set; } = new();

    private Sale() { }

    public Sale(string saleNumber, DateTime date, Guid customerId, Guid branchId)
    {
        Id = Guid.NewGuid();
        SaleNumber = saleNumber;
        Date = date;
        CustomerId = customerId;
        BranchId = branchId;
        Cancelled = false;
    }

    public void AddItem(SaleItem item)
    {
        Items.Add(item);
        RecalculateTotal();
    }

    public void Cancel() => Cancelled = true;

    private void RecalculateTotal()
    {
        TotalAmount = Items.Sum(i => i.Total);
    }
}
