using PharmaMVC.Models;

namespace PharmaMVC.Interfaces;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetTransactions();
    void CreateTransaction(Transaction transaction);
    void AddTransactionItem(TransactionItem transactionItem);
    Task SaveChangesAsync();
}

