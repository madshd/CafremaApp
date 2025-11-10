using CafremaApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafremaApp.Infrastructure.Data;

public class Context : DbContext
{
    protected Context() {}

    public Context(DbContextOptions options) : base(options) { }
    
    // Add DbSet for entities here 
    public DbSet<Inventory> Inventories { get; set; }
}
