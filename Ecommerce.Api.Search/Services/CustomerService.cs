using Ecommerce.Api.Search.Interfaces;
using Ecommerce.Api.Search.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<CustomerService> logger;

        public CustomerService(IHttpClientFactory httpClientFactory, ILogger<CustomerService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, Customer customer, string message)> GetCustomerByIdAsync(int id)
        {
            try
            {
                var client = httpClientFactory.CreateClient("CustomerService");
              
                var result = await client.GetAsync($"/api/Customer/{id}");

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsStringAsync();

                    var customer = JsonConvert.DeserializeObject<Customer>(data);

                    return (true, customer, result.ReasonPhrase);
                }

                return (false, null, result.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());

                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Customer> customer, string message)> GetCustomersAsync(int id)
        {
            try
            {

                var client = httpClientFactory.CreateClient("CustomerService");

                var result = await client.GetAsync($"/api/order/{id}");

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsStringAsync();

                    var customerList = JsonConvert.DeserializeObject<IEnumerable<Customer>>(data);

                    return (true, customerList, result.ReasonPhrase);
                }

                return (false, null, result.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());

                return (false, null, ex.Message);
            }
        }
    }
}
