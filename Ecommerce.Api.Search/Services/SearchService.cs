using Ecommerce.Api.Search.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Services
{
    public class SearchService : ISearchSevice
    {
        private readonly IOrderService service;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;

        public SearchService(IOrderService service, IProductService productService, ICustomerService customerService)
        {
            this.service = service;
            this.productService = productService;
            this.customerService = customerService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int customerId)
        {
            var (customerSuccess, customer, customerErrors) = await customerService.GetCustomerByIdAsync(customerId);

            if(customer == null)
                return (false, customerErrors);

            var (orderSuccess, orders, orderErrors) = await service.GetOrderAsync(customerId);

            var (productSuccess, products, productErrors) = await productService.GetAllProductsAsync();


            if (orderSuccess)
            {
                foreach(var order in orders)
                {
                    foreach(var item in order.Items)
                    {
                        item.ProductName = productSuccess ? products.FirstOrDefault(a => a.Id == item.ProductId)?.Name : "Product Name N/A";                        
                    } 
                }

                var result = new
                {
                    Customer = customer,
                    Orders = orders                    
                };

                return (true, result);
            }

            return (false, orderErrors);
        }
    }
}
