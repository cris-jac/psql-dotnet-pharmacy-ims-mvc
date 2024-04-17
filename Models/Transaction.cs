namespace PharmaMVC.Models;

public class Transaction
{
    public int Id { get; set; }
    public string UserId { get; set; }
    // public User? User { get; set; }
    public DateTime TimeStamp { get; set; }
    public ICollection<TransactionItem> TransactionItems { get; set; }
    public double TotalAmount { get; set; }
    public string? ClientName { get; set; }
    public int? PrescriptionId { get; set; }
}