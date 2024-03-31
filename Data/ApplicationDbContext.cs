using Microsoft.EntityFrameworkCore;
using PharmaMVC.Models;

namespace PharmaMVC.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
}