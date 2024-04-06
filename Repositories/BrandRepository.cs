using Microsoft.EntityFrameworkCore;
using PharmaMVC.Data;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;

namespace PharmaMVC.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BrandRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddBrand(Brand brand)
    {
        _dbContext.Brands.Add(brand);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteBrand(Brand brand)
    {
        _dbContext.Brands.Remove(brand);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Brand?> GetBrandById(int brandId)
    {
        return await _dbContext.Brands.FindAsync(brandId);
    }

    public async Task<IEnumerable<Brand>> GetBrands()
    {
        return await _dbContext.Brands.ToListAsync();
    }

    public async Task<bool> UpdateBrand(int brandId, Brand brand)
    {
        var existingBrand = await _dbContext.Brands.FindAsync(brandId);

        if (existingBrand != null)
        {
            existingBrand.Name = brand.Name;
            existingBrand.IsNational = brand.IsNational;
        }

        _dbContext.Brands.Update(existingBrand);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}