using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Products.Db
{
    public class ProductDbContext : DbContext
    {

        public ProductDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ProductDto> ProductDtos { get; set; }

    }
}
