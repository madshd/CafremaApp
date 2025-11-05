using CafremaApp.Core.Entities.Infrastructure;
using CafremaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CafremaApp.Infrastructure.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Context>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        // Supabase client (singleton)
        var url = configuration["Supabase:Url"];
        var key = configuration["Supabase:Key"];
        services.AddSingleton(new SupabaseClientWrapper(url!, key!));
        
        return services;
    }
}