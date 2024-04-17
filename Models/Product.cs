using System.ComponentModel.DataAnnotations;

namespace PharmaMVC.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    [Required]
    public double Price { get; set; }
    [Required]
    public int Stock { get; set; }
    public string Description { get; set; } = string.Empty;
    [Required]
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
    [Required]
    public int SubcategoryId { get; set; }
    public Subcategory? Subcategory { get; set; }
    public int? TaxId { get; set; }
    public Tax? Tax { get; set; }
    public bool IsAvailable { get; set; }
    [Required]
    public bool RequiresPrescription { get; set; }
}