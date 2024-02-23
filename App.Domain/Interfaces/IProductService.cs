using App.Domain.Models;

namespace App.Domain.Interfaces
{
    public interface IProductService
    {
        Task<PageList<Product>> GetWithOffsetPagination(int pageNumber, int pageSize);
    }
}