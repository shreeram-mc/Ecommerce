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
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<ProductService> logger;

        public ProductService(IHttpClientFactory httpClientFactory, ILogger<ProductService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<Product> products, string ErrorMessage)> GetAllProductsAsync()
        {
            try
            {
                using var client = httpClientFactory.CreateClient("ProductService");
                var res = await client.GetAsync($"/api/products");

                if (res.IsSuccessStatusCode)
                {
                    var content = await res.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

                    return (true, data, res.ReasonPhrase);
                }

                return (false, null, res.ReasonPhrase);
            }
            catch(Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Product product, string ErrorMessage)> GetProductAsync(int productId)
        {
            try
            {
                using var client = httpClientFactory.CreateClient();

                var res = await client.GetAsync($"/api/products/{productId}");

                if (res.IsSuccessStatusCode)
                {
                    var content = await res.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<Product>(content);

                    return (true, data, res.ReasonPhrase);
                }

                return (false, null, res.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
