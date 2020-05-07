using AutoMapper;
using Ecommerce.Api.Customers.Db;
using Ecommerce.Api.Customers.Interfaces;
using Ecommerce.Api.Customers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Customers.Providers
{
    public class CustomerProvider : ICustomerProvider
    {
        private readonly ILogger<CustomerProvider> _logger;
        private readonly IMapper _mapper;
        private readonly CustomerDbContext _context;

        public CustomerProvider(CustomerDbContext context, ILogger<CustomerProvider> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;

            SeedCustomerData();
        }

        private void SeedCustomerData()
        {
            if (!_context.CustomerDtos.Any())
            {
                _context.CustomerDtos.Add(new CustomerDto() { Id = 1, Name = "Shree", Address = "Dortmund No 1", Email = "shree.c@hmai.com", Phone = "98209820982" });
                _context.CustomerDtos.Add(new CustomerDto() { Id = 2, Name = "Sama", Address = "Essen No 21", Email = "asdf.c@hmai.ffa", Phone = "546456456345" });
                _context.CustomerDtos.Add(new CustomerDto() { Id = 3, Name = "Shiva", Address = "Huerht Don a1 1", Email = "asdaf.c@df.com", Phone = "78546456456" });
                _context.CustomerDtos.Add(new CustomerDto() { Id = 4, Name = "Krish", Address = "Apalio No s1", Email = "3sefdsf.c@dfg.com", Phone = "4563242677234" });

                _context.SaveChangesAsync();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Customer> customers, string ErrorMessage)> GetAllCustomersAsync()
        {
            try
            {
                var customer = await _context.CustomerDtos.ToListAsync();

                var result = _mapper.Map<IEnumerable<CustomerDto>, IEnumerable<Customer>>(customer);

                if (result.Any())
                    return (true, result, "");

                return (false, null, "No Data");

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());

                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Customer customers, string ErrorMessage)> GetCustomerAsync(int id)
        {
            try
            {
                var customer = await _context.CustomerDtos.FirstOrDefaultAsync(a=>a.Id == id);

                var result = _mapper.Map<CustomerDto, Customer>(customer);

                if (result!=null)
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
