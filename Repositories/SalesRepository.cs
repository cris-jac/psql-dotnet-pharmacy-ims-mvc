using Microsoft.EntityFrameworkCore;
using PharmaMVC.Data;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;

namespace PharmaMVC.Repositories;

public class SalesRepository : ISalesRepository
{
    private readonly ApplicationDbContext _dbContext;
    public SalesRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SalesBasket?> GetSalesBasket(string userId)
    {
        var basket = await _dbContext.SalesBaskets.Include(x => x.SalesItems).ThenInclude(i => i.Product).FirstOrDefaultAsync(x => x.UserId == userId);
        return basket;
    }

    public async Task AddSalesBasket(SalesBasket basket)
    {
        _dbContext.SalesBaskets.Add(basket);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveSalesBasket(SalesBasket basket)
    {
        _dbContext.SalesBaskets.Remove(basket);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddSalesItem(SalesItem salesItem)
    {
        _dbContext.SalesItems.Add(salesItem);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveSalesItem(SalesItem salesItem)
    {
        _dbContext.SalesItems.Remove(salesItem);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<SalesBasket?> GetBasketById(int basketId)
    {
        // return await _dbContext.SalesBaskets.Include(x => x.SalesItems).FirstOrDefaultAsync(x => x.Id == basketId);
        var basket = await _dbContext.SalesBaskets.Include(x => x.SalesItems).ThenInclude(i => i.Product).FirstOrDefaultAsync(x => x.Id == basketId);
        return basket;
    }
}