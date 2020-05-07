using AutoMapper;
using Ecommerce.Api.Orders.Db;
using Ecommerce.Api.Orders.Interfaces;
using Ecommerce.Api.Orders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Orders.Providers
{
    public class OrderProvider : IOrderProvider
    {
        private readonly ILogger<OrderDto> _logger;
        private readonly IMapper _mapper;
        private readonly OrderDbContext _context;

        public OrderProvider(OrderDbContext context, ILogger<OrderDto> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;

            SeedData();
        }

        private void SeedData()
        {
            if (!_context.OrdersDto.Any())
            { 
                _context.OrdersDto.Add(new OrderDto()
                {
                    Id = 1,
                    OrderDate = DateTime.Now,
                    CustomerId = 1,
                    Total = 100,
                    ItemDtos = null
                });
                _context.OrdersDto.Add(new OrderDto()
                {
                    Id = 2,
                    OrderDate = DateTime.Now,
                    CustomerId = 2,
                    Total = 3020,
                    ItemDtos =null
                }
                );

                _context.SaveChangesAsync();
            }

            if (!_context.OrdersDto.Any(a=>a.ItemDtos == null))
            {
                var list = GetListOfOrderdItems(1);
                var list2 = GetNextListOfOrderdItems(2);

                _context.OrdersDto.FirstOrDefault(a => a.Id == 1).ItemDtos = list;
                _context.OrdersDto.FirstOrDefault(a => a.Id == 2).ItemDtos = list2;

                _context.SaveChangesAsync();
            }
        }

        private List<ItemDto> GetListOfOrderdItems(int id)
        {
            var list = new List<ItemDto>
            {
                new ItemDto { Id = 1, OrderId=id, UnitPrice = 2331 , ProductId=1, Quantity=20},
                new ItemDto { Id = 2, OrderId=id, UnitPrice = 1010 , ProductId=2, Quantity=5},
                new ItemDto { Id = 3, OrderId=id, UnitPrice = 2100 , ProductId=3, Quantity=2}
            };

            _context.ItemsDto.AddRangeAsync(list);

            _context.SaveChangesAsync();

            return list;
        }
        private List<ItemDto> GetNextListOfOrderdItems(int id)
        {
            var list = new List<ItemDto>
            {
                new ItemDto { Id = 4, OrderId=id, UnitPrice = 888 , ProductId=1, Quantity=20},
                new ItemDto { Id = 5, OrderId=id, UnitPrice = 555 , ProductId=2, Quantity=5},
                new ItemDto { Id = 6, OrderId=id, UnitPrice = 666 , ProductId=3, Quantity=2}
            };

            _context.ItemsDto.AddRangeAsync(list);

            _context.SaveChangesAsync();

            return list;
        }

       

        public async Task<(bool IsSuccess, IEnumerable<Order> orders, string error)> GetOrderAsync(int id)
        {
            try
            {
                var orderResult = await _context.OrdersDto.Where(a => a.CustomerId == id).ToListAsync();

                //if (order.)
                //    order.ItemDtos = await _context.ItemsDto.Where(a => a.OrderId == order.Id).ToListAsync();

                var result = _mapper.Map<IEnumerable<OrderDto>, IEnumerable<Order>>(orderResult);

                if (result != null)
                    return (true, result, "");

                return (false, null, "Not found");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                return (false, null, ex.Message);
            }
        }
    }
}
