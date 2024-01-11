using Microsoft.EntityFrameworkCore;

namespace E_Commerces.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }
    public DbSet<Product> Products{get;set;}
}
