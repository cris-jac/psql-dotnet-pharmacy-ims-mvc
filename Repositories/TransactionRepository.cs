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
        return await _dbContext.Transactions.Include(x => x.User).ToListAsync();
    }

    public async Task<IEnumerable<DataSalesPerMonthViewModel>> GetTransactionsByTimePeriod(DateTime startDate, DateTime endDate)
    {
        // var transactions = await _dbContext.Transactions
        //     .Where(t => t.TimeStamp >= startDate && t.TimeStamp <= endDate)
        //     .Select(t => new
        //     {
        //         Year = t.TimeStamp.Year,
        //         Month = t.TimeStamp.Month,
        //         SalesCount = 1
        //     })
        //     .GroupBy(g => new { g.Year, g.Month })
        //     .Select(g => new DataSalesPerMonthViewModel
        //     {
        //         Year = g.Key.Year,
        //         Month = g.Key.Month,
        //         SalesCount = g.Sum(t => t.SalesCount)
        //     })
        //     .OrderBy(g => new { g.Year, g.Month })
        //     .ToListAsync();

        var transactions = await _dbContext.Transactions
            .Where(t => t.TimeStamp >= startDate && t.TimeStamp <= endDate)
            .GroupBy(t => new { t.TimeStamp.Year, t.TimeStamp.Month })
            .Select(g => new
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                SalesCount = g.Count()
            })
            .OrderBy(g => g.Year)
            .ThenBy(g => g.Month)
            .ToListAsync();

        var groupedTransactions = transactions.Select(g => new DataSalesPerMonthViewModel
        {
            Year = g.Year,
            Month = g.Month,
            SalesCount = g.SalesCount
        });

        return groupedTransactions;
    }

    public async Task<Transaction?> GetTransactionById(int transactionId)
    {
        return await _dbContext.Transactions.Include(x => x.User).Include(x => x.TransactionItems).FirstOrDefaultAsync(x => x.Id == transactionId);
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