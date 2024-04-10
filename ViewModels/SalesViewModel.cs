using PharmaMVC.Models;

namespace PharmaMVC.ViewModels;

public class SalesViewModel
{
    public int ProductId { get; set; }
    public int QuantityToSell { get; set; }
    public IEnumerable<Product> Products { get; set; }
}