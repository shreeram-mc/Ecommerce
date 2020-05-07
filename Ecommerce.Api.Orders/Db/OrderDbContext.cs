using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Api.Orders.Db
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<OrderDto> OrdersDto { get; set; }

        public DbSet<ItemDto> ItemsDto { get; set; }
    }
}
