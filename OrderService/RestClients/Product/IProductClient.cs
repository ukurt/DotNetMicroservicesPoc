using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Retry;
using ProductService.Api.Queries;
using ProductService.Api.Queries.Dtos;
using RestEase;

namespace OrderService.RestClients
{
    public interface IProductClient
    {
        Task<ProductDto> GetProduct([Body] FindProductByIdQuery cmd);
    }

    public class ProductClient : IProductClient
    {
        private readonly IProductClient client;

        private static AsyncRetryPolicy retryPolicy = Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(3));

        public ProductClient(IConfiguration configuration)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(configuration.GetValue<string>("ProductServiceUri"))
            };
            client = RestClient.For<IProductClient>(httpClient);
        }

        public Task<ProductDto> GetProduct([Body] FindProductByIdQuery cmd)
        {
            return retryPolicy.ExecuteAsync(async () => await client.GetProduct(cmd));
        }
    }
}
