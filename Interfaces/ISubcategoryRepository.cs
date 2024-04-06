using PharmaMVC.Models;

namespace PharmaMVC.Interfaces;

public interface ISubcategoryRepository
{
    Task<IEnumerable<Subcategory>> GetSubcategories();
    Task<Subcategory?> GetSubcategoryById(int subcategoryId);
    Task<bool> AddSubcategory(Subcategory subcategory);
    Task<bool> UpdateSubcategory(int subcategoryId, Subcategory subcategory);
    Task<bool> DeleteSubcategory(Subcategory subcategory);
}