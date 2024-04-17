using PharmaMVC.Models;

namespace PharmaMVC.ViewModels;

public class ProductViewModel
{
    public IEnumerable<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    public IEnumerable<Brand> Brands { get; set; } = new List<Brand>();
    public IEnumerable<Tax> Taxes { get; set; } = new List<Tax>();
    public Product Product { get; set; } = new Product();
}