using PharmaMVC.Models;

namespace PharmaMVC.Interfaces;

public interface ISalesRepository
{
    Task<SalesBasket?> GetSalesBasket(string userId);
    Task AddSalesBasket(SalesBasket basket);
    Task RemoveSalesBasket(SalesBasket basket);
    Task AddSalesItem(SalesItem salesItem);
    Task RemoveSalesItem(SalesItem salesItem);
    Task SaveChangesAsync();
}