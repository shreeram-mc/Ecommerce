using AutoMapper;
using Ecommerce.Api.Products.Db;
using Ecommerce.Api.Products.Interfaces;
using Ecommerce.Api.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Products.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly ProductDbContext _context;
        private readonly ILogger<ProductProvider> _logger;
        private readonly IMapper _mapper;

        public ProductProvider(ProductDbContext context, ILogger<ProductProvider> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!_context.ProductDtos.Any())
            {
                _context.ProductDtos.Add(new ProductDto() { Id = 1, Name = "Mouse", Inventory = 100, Price = 250 });
                _context.ProductDtos.Add(new ProductDto() { Id = 2, Name = "Keyboard", Inventory = 412, Price = 1250 });
                _context.ProductDtos.Add(new ProductDto() { Id = 3, Name = "Monitor", Inventory = 12, Price = 6000 });
                _context.ProductDtos.Add(new ProductDto() { Id = 4, Name = "CPU", Inventory = 568, Price = 7000 });

                _context.SaveChanges();
            }
        }

        public async Task<(bool IsSuccesss, IEnumerable<Product> Products, string ErrorMessage)> GetAllProductsAsync()
        {
            try
            {
                var products = await _context.ProductDtos.ToListAsync();

                if (products.Any())
                {
                    var result = _mapper.Map<IEnumerable<ProductDto>, IEnumerable<Product>>(products);

                    return (true, result, "");
                }

                return (false, null, "No Data");

            }catch(Exception ex)
            {
                _logger?.LogError(ex.ToString());

                return (false, null, ex.Message);
            }             
        }


        public async Task<(bool IsSuccesss, Product Product, string ErrorMessage)> GetProductAsync(int id)
        {
            try
            {
                var product = await _context.ProductDtos.FirstOrDefaultAsync(a=>a.Id == id);

                if (product != null)
                {
                    var result = _mapper.Map<ProductDto, Product>(product);

                    return (true, result, "");
                }

                return (false, null, "No Data");

            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());

                return (false, null, ex.Message);
            }
        }
    }
}
