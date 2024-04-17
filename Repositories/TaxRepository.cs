using Microsoft.EntityFrameworkCore;
using PharmaMVC.Data;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;

namespace PharmaMVC.Controllers;

public class TaxRepository : ITaxRepository
{
    private readonly ApplicationDbContext _dbContext;
    public TaxRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddTax(Tax tax)
    {
        _dbContext.Taxes.Add(tax);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteTax(Tax tax)
    {
        _dbContext.Taxes.Remove(tax);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Tax>> GetTaxes()
    {
        return await _dbContext.Taxes.ToListAsync();
    }

    public async Task<Tax?> GetTaxById(int taxId)
    {
        return await _dbContext.Taxes.FirstOrDefaultAsync(x => x.Id == taxId);
    }

    public async Task<bool> UpdateTax(int taxId, Tax tax)
    {
        var existingTax = await _dbContext.Taxes.FirstOrDefaultAsync(x => x.Id == taxId);

        if (existingTax != null)
        {
            existingTax.Name = tax.Name;
            existingTax.Description = tax.Description;
            existingTax.Rate = tax.Rate;
        }
        _dbContext.Taxes.Update(existingTax);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}