namespace PharmaMVC.Models;

public class SalesBasket
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public AppUser? User { get; set; }
    public ICollection<SalesItem> SalesItems { get; set; }
}