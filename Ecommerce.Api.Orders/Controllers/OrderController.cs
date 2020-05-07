using Ecommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Api.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProvider _provider;

        public OrderController(IOrderProvider provider)
        {
            _provider = provider;
        }

      

        [HttpGet("{customerid}")]
        public async Task<IActionResult> GetOrderAsync(int customerid)
        {
            var (IsSuccess, Order, ErrorMessage) = await _provider.GetOrderAsync(customerid);

            if (IsSuccess)
            {
                return Ok(Order);
            }

            return NotFound(ErrorMessage);
        }
    }
}