using PharmaMVC.Models;

namespace PharmaMVC.ViewModels;

public class SubcategoryViewModel
{
    public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    public Subcategory Subcategory { get; set; } = new Subcategory();
}