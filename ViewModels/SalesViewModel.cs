using PharmaMVC.Models;

namespace PharmaMVC.ViewModels;

public class SalesViewModel
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int UpdateQuantityBy { get; set; }
    public IEnumerable<Product> Products { get; set; }
}