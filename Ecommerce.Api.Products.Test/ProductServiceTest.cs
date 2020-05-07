using AutoMapper;
using Ecommerce.Api.Products.Db;
using Ecommerce.Api.Products.Profiles;
using Ecommerce.Api.Products.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using Xunit;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Products.Test
{
    public class ProductServiceTest
    {
        [Fact]
        public async Task GetProductsReturnsAllProducts()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(nameof(GetProductsReturnsAllProducts)).Options;

            var db = new ProductDbContext(options);

            CreateProducts(db);

            var pprofile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(pprofile));

            var mapper = new Mapper(configuration);

            var productsProvider = new ProductProvider(db, null, mapper);

            var res = await productsProvider.GetAllProductsAsync();

            Assert.True(res.IsSuccesss);

            Assert.True(res.Products.Any());

            Assert.Equal("", res.ErrorMessage);
        }

        [Fact]
        public async Task GetProductsReturnsProductUsingValidId()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(nameof(GetProductsReturnsProductUsingValidId)).Options;

            var db = new ProductDbContext(options);

            CreateProducts(db);

            var pprofile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(pprofile));

            var mapper = new Mapper(configuration);

            var productsProvider = new ProductProvider(db, null, mapper);

            var res = await productsProvider.GetProductAsync(1);

            Assert.True(res.IsSuccesss);

            Assert.Equal(1, res.Product.Id);

            Assert.Equal("", res.ErrorMessage);
        }

        [Fact]
        public async Task GetProductsReturnsNotFoundUsingInvalidId()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(nameof(GetProductsReturnsNotFoundUsingInvalidId)).Options;

            var db = new ProductDbContext(options);

            CreateProducts(db);

            var pprofile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(pprofile));

            var mapper = new Mapper(configuration);

            var productsProvider = new ProductProvider(db, null, mapper);

            var res = await productsProvider.GetProductAsync(-1);

            Assert.False(res.IsSuccesss);

            Assert.Null(res.Product);

            Assert.NotNull(res.ErrorMessage);
        }

        private void CreateProducts(ProductDbContext db)
        {
            for (int i = 1; i < 11; i++)
            {
                db.ProductDtos.Add(new ProductDto() { Id = i, Name = Guid.NewGuid().ToString(), Inventory = i + 5, Price = (decimal)(i * 3.14) });
            }

            db.SaveChanges();
        }
    }
}
