using Microsoft.EntityFrameworkCore;
using PharmaMVC.Data;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;

namespace PharmaMVC.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddProduct(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteProduct(Product product)
    {
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Product?> GetProductById(int productId)
    {
        return await _dbContext.Products.Include(p => p.Brand).Include(p => p.Subcategory).ThenInclude(s => s.Category).Include(p => p.Tax).FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _dbContext.Products.Include(p => p.Brand).Include(p => p.Subcategory).ThenInclude(s => s.Category).Include(p => p.Tax).ToListAsync();
    }

    public async Task UpdateProduct(int productId, Product product)
    {
        var existingProduct = await _dbContext.Products.Include(p => p.Brand).Include(p => p.Subcategory).ThenInclude(s => s.Category).Include(p => p.Tax).FirstOrDefaultAsync(p => p.Id == productId);

        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.SKU = product.SKU;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            existingProduct.Description = product.Description;
            existingProduct.BrandId = product.BrandId;
            existingProduct.SubcategoryId = product.SubcategoryId;
            existingProduct.TaxId = product.TaxId;
            existingProduct.IsAvailable = product.IsAvailable;
            existingProduct.RequiresPrescription = product.RequiresPrescription;
        }

        _dbContext.Products.Update(existingProduct);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> SearchProducts(string searchTerm)
    {
        // var filteredProducts = _dbContext.Products.AsQueryable();

        // if (searchTerm != null)
        // {
        searchTerm = searchTerm.Trim().ToLower();

        var filteredProducts = await _dbContext.Products
            .Where(x =>
                x.Name.ToLower().Contains(searchTerm) ||
                x.SKU.ToLower().Contains(searchTerm))
            .ToListAsync();
        // }

        return filteredProducts;


        // var result = await _dbContext.Products
        //     .Where(x => x.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
        //         x.SKU.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
        //     .ToListAsync();
        // return result;
    }
}