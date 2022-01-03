using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Retry;
using ProductService.Api.Queries;
using ProductService.Api.Queries.Dtos;
using RestEase;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace OrderService.RestClients
{
    public interface IProductClient
    {
        Task<ProductDto> FindProductById([Query] FindProductByIdQuery cmd);
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


        public Task<ProductDto> FindProductById([Query] FindProductByIdQuery cmd)
        {
            return retryPolicy.ExecuteAsync(async () => await client.FindProductById(cmd));
        }
    }
}
