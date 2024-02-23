using App.Domain.Interfaces;
using App.Domain.Models;
using App.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories
{
    public class OrderRepository(ApplicationDbContext dbContext) : IOrderRepository
    {
        private readonly ApplicationDbContext dbContext = dbContext;
        public async Task<PageList<Order>> GetWithOffsetPagination(int pageNumber, int pageSize)
        {
            var totalRecords = await this.dbContext.Orders.AsNoTracking().CountAsync();

            var orders = await this.dbContext.Orders.AsNoTracking()
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var pagedResponse = new PageList<Order>(orders, pageNumber, pageSize, totalRecords);

            return pagedResponse;
        }
    }
}