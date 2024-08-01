using CoffeeAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CoffeeAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<CoffeeDay> CoffeeDays { get; set; }
}
