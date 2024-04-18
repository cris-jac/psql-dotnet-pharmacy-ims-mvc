using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmaMVC.Models;

namespace PharmaMVC.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }
    public DbSet<Tax> Taxes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SalesBasket> SalesBaskets { get; set; }
    public DbSet<SalesItem> SalesItems { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionItem> TransactionItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppRole>()
            .HasData(
                new AppRole { Id = 1, Name = StaticRoles.User, NormalizedName = StaticRoles.User.ToUpper() },
                new AppRole { Id = 2, Name = StaticRoles.Admin, NormalizedName = StaticRoles.Admin.ToUpper() }
            );
    }
}