using PharmaMVC.Models;

namespace PharmaMVC.ViewModels;

public class SalesViewModel
{
    public string UserId { get; set; } = string.Empty; // Added
    public int ProductId { get; set; }
    public int UpdateQuantityBy { get; set; }
    public IEnumerable<Product> Products { get; set; }
}