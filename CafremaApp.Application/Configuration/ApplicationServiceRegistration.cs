using CafremaApp.Application.Services;
using CafremaApp.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CafremaApp.Application.Configuration;

public static class ApplicationServiceRegistration 
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // 1. Registrer Application Services (Implementering af Core Interfaces)
        // Her knyttes IInventoryService (fra Core) til InventoryService (fra Application).
        services.AddScoped<IInventoryService, InventoryService>();
        
        // Hvis du har andre App Services (f.eks. IOrderService), skal de også registreres her:
        // services.AddScoped<IOrderService, OrderService>();

        return services;
    }
}