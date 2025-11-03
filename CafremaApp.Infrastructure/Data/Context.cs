using Microsoft.EntityFrameworkCore;

namespace CafremaApp.Infrastructure.Data;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
    }
}
