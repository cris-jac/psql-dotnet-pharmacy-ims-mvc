using Microsoft.EntityFrameworkCore;
using PharmaMVC.Data;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;

namespace PharmaMVC.Repositories;

public class SubcategoryRepository : ISubcategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    public SubcategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddSubcategory(Subcategory subcategory)
    {
        _dbContext.Subcategories.Add(subcategory);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteSubcategory(Subcategory subcategory)
    {
        _dbContext.Subcategories.Remove(subcategory);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Subcategory>> GetSubcategories()
    {
        return await _dbContext.Subcategories.Include(x => x.Category).ToListAsync();
    }

    public async Task<Subcategory?> GetSubcategoryById(int subcategoryId)
    {
        return await _dbContext.Subcategories.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == subcategoryId);
    }

    public async Task<bool> UpdateSubcategory(int subcategoryId, Subcategory subcategory)
    {
        var existingSubcategory = await _dbContext.Subcategories.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == subcategoryId);

        if (existingSubcategory != null)
        {
            existingSubcategory.Name = subcategory.Name;
            existingSubcategory.CategoryId = subcategory.CategoryId;
            existingSubcategory.Category = subcategory.Category;
        }

        _dbContext.Subcategories.Update(existingSubcategory);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}