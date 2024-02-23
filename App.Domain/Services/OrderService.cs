using App.Domain.Interfaces;
using App.Domain.Models;

namespace App.Domain.Services
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        private readonly IOrderRepository orderRepository = orderRepository;

        public Task<PageList<Order>> GetWithOffsetPagination(int pageNumber, int pageSize)
        {
            return this.orderRepository.GetWithOffsetPagination(pageNumber, pageSize);
        }
    }
}