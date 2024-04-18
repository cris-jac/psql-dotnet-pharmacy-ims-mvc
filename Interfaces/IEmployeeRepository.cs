using PharmaMVC.Models;

namespace PharmaMVC.Interfaces;

public interface IEmployeeRepository
{
    Task<IEnumerable<AppUser>> GetAllEmployees();
    Task<AppUser?> GetUserById(int id);
}