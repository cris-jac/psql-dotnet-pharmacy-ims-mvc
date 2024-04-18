using PharmaMVC.Models;

namespace PharmaMVC.Interfaces;

public interface ISalesRepository
{
    Task<SalesBasket?> GetSalesBasket(int userId);
    Task AddSalesBasket(SalesBasket basket);
    Task RemoveSalesBasket(SalesBasket basket);
    Task AddSalesItem(SalesItem salesItem);
    Task RemoveSalesItem(SalesItem salesItem);
    Task SaveChangesAsync();
    Task<SalesBasket?> GetBasketById(int basketId);
}