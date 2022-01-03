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
        [Get("api/products")]
        Task<ProductDto> FindProductById(int productId);
    }

    public class ProductClient : IProductClient
    {
        private readonly IProductClient client;

        private static AsyncRetryPolicy retryPolicy = Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(3));

        public ProductClient(IConfiguration configuration)
        {
            client = RestClient.For<IProductClient>(configuration.GetValue<string>("ProductServiceUri"));
        }


        public Task<ProductDto> FindProductById(int productId)
        {
            return retryPolicy.ExecuteAsync(async () => await client.FindProductById(productId));
        }
    }
}
