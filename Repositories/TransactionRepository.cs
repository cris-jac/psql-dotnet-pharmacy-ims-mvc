using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaMVC.Data;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;

namespace PharmaMVC.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TransactionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Transaction>> GetTransactions()
    {
        return await _dbContext.Transactions.ToListAsync();
    }

    public void CreateTransaction(Transaction transaction)
    {
        _dbContext.Transactions.Add(transaction);
    }

    public void AddTransactionItem(TransactionItem transactionItem)
    {
        _dbContext.TransactionItems.Add(transactionItem);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}