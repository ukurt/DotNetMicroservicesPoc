using Microsoft.Extensions.DependencyInjection;


namespace OrderService.Init
{
    public static class DataLoaderInstaller
    {
        public static IServiceCollection AddOrderDemoInitializer(this IServiceCollection services)
        {
            services.AddScoped<DataLoader>();
            return services;
        }
    }
}
