using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Customers.Db
{
    public class CustomerDbContext: DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CustomerDto> CustomerDtos { get; set; }
    }
}
