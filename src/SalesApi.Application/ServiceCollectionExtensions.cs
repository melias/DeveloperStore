using Microsoft.Extensions.DependencyInjection;
using SalesApi.Application.Services;

namespace SalesApi.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
