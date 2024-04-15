namespace PharmaMVC.Models;

public class SalesBasket
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public ICollection<SalesItem> SalesItems { get; set; }
}