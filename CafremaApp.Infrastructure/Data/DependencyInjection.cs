using CafremaApp.Core.Entities;
using CafremaApp.Core.Entities.Infrastructure;
using CafremaApp.Core.Interfaces;
using CafremaApp.Infrastructure.Data;
using CafremaApp.Infrastructure.Repositories;
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
        
        services.AddScoped<IGenericRepository<Inventory>, InventoryRepository>();
        services.AddScoped<IGenericRepository<Appliance>, ApplianceRepository>();
        services.AddScoped<IGenericRepository<Room>, RoomRepository>();
        
        return services;
    }
}