using Ecommerce.Api.Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Api.Products.Interfaces
{
    public interface IProductProvider
    {
        Task<(bool IsSuccesss, IEnumerable<Product> Products, string ErrorMessage)> GetAllProductsAsync();

        Task<(bool IsSuccesss, Product Product, string ErrorMessage)> GetProductAsync(int id);
    }
}
