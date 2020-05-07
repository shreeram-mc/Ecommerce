using Ecommerce.Api.Customers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Api.Customers.Interfaces
{
    public interface ICustomerProvider
    {
        Task<(bool IsSuccess, IEnumerable<Customer> customers, string ErrorMessage)> GetAllCustomersAsync();

        Task<(bool IsSuccess, Customer customers, string ErrorMessage)> GetCustomerAsync(int id);
    }
}
