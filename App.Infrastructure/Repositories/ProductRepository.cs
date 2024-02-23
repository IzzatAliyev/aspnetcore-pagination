using App.Domain.Interfaces;
using App.Domain.Models;
using App.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories
{
    public class ProductRepository(ApplicationDbContext dbContext) : IProductRepository
    {
        private readonly ApplicationDbContext dbContext = dbContext;
        public async Task<PageList<Product>> GetWithOffsetPagination(int pageNumber, int pageSize)
        {
            var totalRecords = await this.dbContext.Products.AsNoTracking().CountAsync();

            var products = await this.dbContext.Products.AsNoTracking()
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var pagedResponse = new PageList<Product>(products, pageNumber, pageSize, totalRecords);

            return pagedResponse;
        }
    }
}