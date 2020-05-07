using Ecommerce.Api.Search.Interfaces;
using Ecommerce.Api.Search.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Services
{
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<OrderService> logger;

        public OrderService(IHttpClientFactory httpClientFactory, ILogger<OrderService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<Order> orders, string ErrorMessage)> GetOrderAsync(int customerId)
        {
            try {

                var client = httpClientFactory.CreateClient("OrderService");

                var result = await client.GetAsync($"/api/order/{customerId}");

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsStringAsync();
                    
                    var ordersList = JsonConvert.DeserializeObject<IEnumerable<Order>>(data);

                    return (true, ordersList, result.ReasonPhrase);
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
