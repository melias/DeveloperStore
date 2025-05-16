namespace SalesApi.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public string Category { get; private set; } = null!;
    public string Image { get; private set; } = null!;

    private Product() { }

    public Product(string name, string description, decimal price, string category, string image)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Image = image;
    }

    public void Update(string name, string description, decimal price, string category, string image)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Image = image;
    }
}
