using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaMVC.Data;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;

namespace PharmaMVC.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public EmployeeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<AppUser>> GetAllEmployees()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<AppUser?> GetUserById(int id)
    {
        return await _dbContext.Users.FindAsync(id);
    }
}