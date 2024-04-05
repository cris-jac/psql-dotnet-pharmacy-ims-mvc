using PharmaMVC.Models;

namespace PharmaMVC.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category?> GetCategoryById(int categoryId);
    Task<bool> AddCategory(Category category);
    Task<bool> UpdateCategory(int categoryId, Category category);
    Task<bool> DeleteCategory(Category category);
}