namespace PharmaMVC.Models;

public class TransactionItem
{
    public int Id { get; set; }
    public int TransactionId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int StockBeforeSell { get; set; }
    public int StockRemaining { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double TaxAmount { get; set; }
    public double FinalPrice { get; set; }
}