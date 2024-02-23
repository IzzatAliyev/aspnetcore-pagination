using App.Domain.Models;

namespace App.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<PageList<Order>> GetWithOffsetPagination(int pageNumber, int pageSize);
    }
}