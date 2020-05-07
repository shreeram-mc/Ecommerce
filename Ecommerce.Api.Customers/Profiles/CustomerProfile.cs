using Ecommerce.Api.Customers.Db;
using Ecommerce.Api.Customers.Models;

namespace Ecommerce.Api.Customers.Profiles
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>();
        }
    }
}
