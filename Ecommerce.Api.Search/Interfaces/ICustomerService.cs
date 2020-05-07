using Ecommerce.Api.Search.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Interfaces
{
    public interface ICustomerService
    {
        Task<(bool IsSuccess, Customer customer, string message)> GetCustomerByIdAsync(int id);

        Task<(bool IsSuccess, IEnumerable<Customer> customer, string message)> GetCustomersAsync(int id);
    }
}
