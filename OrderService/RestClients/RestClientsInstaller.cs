using Microsoft.Extensions.DependencyInjection;
using OrderService.Domain;

namespace OrderService.RestClients
{
    public static class RestClientsInstaller
    {
        public static IServiceCollection AddOrderRestClient(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IProductClient), typeof(ProductClient));
            services.AddSingleton(typeof(IProductService), typeof(ProductService));
            services.AddSingleton(typeof(ICustomerClient), typeof(CustomerClient));
            services.AddSingleton(typeof(ICustomerService), typeof(CustomerService));

            return services;
        }
    }
}
