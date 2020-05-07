using System.Threading.Tasks;
using Ecommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
      private readonly IProductProvider _provider;

        public ProductsController(IProductProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var (IsSuccess, Products, ErrorMessage) = await _provider.GetAllProductsAsync();

            if (IsSuccess)
            {
                return Ok(Products);
            }

            return NotFound(ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var (IsSuccess, Product, ErrorMessage) = await _provider.GetProductAsync(id);

            if (IsSuccess)
            {
                return Ok(Product);
            }

            return NotFound(ErrorMessage);
        }
    }
}