using Ecommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Interfaces
{
    public interface IProductService
    {
        Task<(bool IsSuccess, IEnumerable<Product> products, string ErrorMessage)> GetAllProductsAsync();

        Task<(bool IsSuccess, Product product, string ErrorMessage)> GetProductAsync(int productId);
    }
}
