namespace PharmaMVC.Models;

public class SalesItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public int SalesBasketId { get; set; }
}