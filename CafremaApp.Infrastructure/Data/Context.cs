using Microsoft.EntityFrameworkCore;

namespace CafremaApp.Infrastructure.Data;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // // Supabase-tabeller ligger ofte i 'public' skemaet
        // modelBuilder.HasDefaultSchema("public");
    }
}
