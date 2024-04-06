namespace PharmaMVC.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; } = string.Empty;
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
    public int SubcategoryId { get; set; }
    public Subcategory? Subcategory { get; set; }
    public bool IsAvailable { get; set; }
    public bool RequiresPrescription { get; set; }
}