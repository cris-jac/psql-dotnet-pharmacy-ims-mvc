using PharmaMVC.Models;

namespace PharmaMVC.Interfaces;

public interface ITaxRepository
{
    Task<bool> AddTax(Tax tax);
    Task<bool> DeleteTax(Tax tax);
    Task<IEnumerable<Tax>> GetTaxes();
    Task<Tax?> GetTaxById(int taxId);
    Task<bool> UpdateTax(int taxId, Tax tax);
}