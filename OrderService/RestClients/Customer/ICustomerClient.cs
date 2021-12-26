using System;
using System.Net.Http;
using System.Threading.Tasks;
using CustomerService.Api.Queries;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Retry;
using RestEase;

namespace OrderService.RestClients
{
    public interface ICustomerClient
    {
        Task<FindCustomerResult> GetCustomer([Body] FindCustomerQuery cmd);
    }

    public class CustomerClient : ICustomerClient
    {
        private readonly ICustomerClient client;

        private static AsyncRetryPolicy retryPolicy = Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(3));

        public CustomerClient(IConfiguration configuration)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(configuration.GetValue<string>("CustomerServiceUri"))
            };
            client = RestClient.For<ICustomerClient>(httpClient);
        }

        public async Task<FindCustomerResult> GetCustomer([Body] FindCustomerQuery cmd)
        {
            return await retryPolicy.ExecuteAsync(async () => await client.GetCustomer(cmd));
        }
    }
}
