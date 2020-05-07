using Ecommerce.Api.Orders.Db;
using Ecommerce.Api.Orders.Models;
using System.Collections.Generic;

namespace Ecommerce.Api.Orders.Profiles
{
    public class OrderProfile : AutoMapper.Profile
    {

        public OrderProfile()
        {
            CreateMap<OrderDto,Order>()
                .ForMember(t => t.Items, options => options.MapFrom(source => source.ItemDtos));

            CreateMap<ItemDto, Item>();
        }

    }
}
