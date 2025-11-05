using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CafremaApp.Infrastructure.Data;

public class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Context>();
        
        optionsBuilder.UseNpgsql("User Id=postgres.svimcgjnchossfivbzka;Password=Rl6aIvMTaUUcfHER;Server=aws-1-eu-north-1.pooler.supabase.com;Port=5432;Database=postgres");
        
        return new Context(optionsBuilder.Options);
    }
}