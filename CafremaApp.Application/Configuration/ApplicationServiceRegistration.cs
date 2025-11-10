using AutoMapper;
using CafremaApp.Application.Services;
using CafremaApp.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CafremaApp.Application.Configuration;

public static class ApplicationServiceRegistration 

{
/// <summary>
        /// Registers application services for dependency injection.
        /// Scoped services have a lifetime that matches the duration of an HTTP request.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which the services will be added.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services by linking interfaces to their implementations.
            // Scoped services have a lifetime that matches the duration of an HTTP request.
        
            // Registers the IInventoryService interface to be resolved by the InventoryService implementation.
            services.AddScoped<IInventoryService, InventoryService>();
            
            
            return services;
        }
}