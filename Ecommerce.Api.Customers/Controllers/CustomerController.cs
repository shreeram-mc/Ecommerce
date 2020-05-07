using System.Threading.Tasks;
using Ecommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerProvider customerProvider;

        public CustomerController(ICustomerProvider provider)
        {
            customerProvider = provider;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var (success, customer, error) = await customerProvider.GetAllCustomersAsync();

            if (success)
                return Ok(customer);

            return NotFound(error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCustomers(int id)
        {
            var (success, customer, error) = await customerProvider.GetCustomerAsync(id);

            if (success)
                return Ok(customer);

            return NotFound(error);
        }
    }
}