using System;
using System.Net.Http;
using System.Threading.Tasks;
using CustomerService.Api.Queries;
using CustomerService.Api.Queries.Dtos;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Retry;
using RestEase;

namespace OrderService.RestClients
{
    public interface ICustomerClient
    {
        [Get("api/customer")]
        Task<CustomerDto> GetByCode(int customerId);
    }

    public class CustomerClient : ICustomerClient
    {
        private readonly ICustomerClient client;

        private static AsyncRetryPolicy retryPolicy = Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(3));

        public CustomerClient(IConfiguration configuration)
        {
            client = RestClient.For<ICustomerClient>(configuration.GetValue<string>("CustomerServiceUri"));
        }


        public async Task<CustomerDto> GetByCode(int customerId)
        {
            return await retryPolicy.ExecuteAsync(async () => await client.GetByCode(customerId));
        }
    }
}
