using PharmaMVC.Models;

namespace PharmaMVC.Interfaces;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetBrands();
    Task<Brand?> GetBrandById(int brandId);
    Task<bool> AddBrand(Brand brand);
    Task<bool> UpdateBrand(int brandId, Brand brand);
    Task<bool> DeleteBrand(Brand brand);
}