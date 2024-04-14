namespace PharmaMVC.Models;

public class SaleBasket
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public ICollection<SaleItem> SaleItems { get; set; }
}