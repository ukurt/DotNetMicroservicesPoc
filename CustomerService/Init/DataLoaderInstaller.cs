using Microsoft.Extensions.DependencyInjection;


namespace CustomerService.Init
{
    public static class DataLoaderInstaller
    {
        public static IServiceCollection AddCustomerDemoInitializer(this IServiceCollection services)
        {
            services.AddScoped<DataLoader>();
            return services;
        }
    }
}
