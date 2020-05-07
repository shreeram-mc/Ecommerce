using Ecommerce.Api.Orders.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Api.Orders.Interfaces
{
    public interface IOrderProvider
    { 
        Task<(bool IsSuccess, IEnumerable<Order> orders, string error)> GetOrderAsync(int id);
    }
}
