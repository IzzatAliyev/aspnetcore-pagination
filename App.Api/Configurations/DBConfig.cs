using App.Domain.Models;
using App.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Configurations
{
    public static class DBConfig
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static void CreateDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.EnsureCreated();
            }
        }

        public static void PopulateDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var numberOfProductsToSeed = 100_000;
                var numberOfOrdersToSeed = 1_000;

                if (!dbContext.Products.Any())
                {
                    var products = Enumerable.Range(1, numberOfProductsToSeed).Select(i => new Product { Name = $"Product {i}" });
                    dbContext.Products.AddRange(products);
                    dbContext.SaveChanges();
                }

                if (!dbContext.Orders.Any())
                {
                    var orders = Enumerable.Range(1, numberOfOrdersToSeed).Select(i => new Order { Code = $"ORDER-{i}" });
                    dbContext.Orders.AddRange(orders);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}