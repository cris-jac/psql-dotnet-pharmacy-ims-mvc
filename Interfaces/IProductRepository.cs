using PharmaMVC.Models;

namespace PharmaMVC.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProductById(int productId);
    Task AddProduct(Product product);
    Task UpdateProduct(int productId, Product product);
    Task DeleteProduct(Product product);
    Task<IEnumerable<Product>> SearchProducts(string searchTerm);
}