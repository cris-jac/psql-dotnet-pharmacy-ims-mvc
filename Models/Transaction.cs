namespace PharmaMVC.Models;

public class Transaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public AppUser? User { get; set; }
    public DateTime TimeStamp { get; set; }
    public ICollection<TransactionItem> TransactionItems { get; set; }
    public double TotalAmount { get; set; }
    public string? ClientName { get; set; }
    public int? PrescriptionId { get; set; }
}