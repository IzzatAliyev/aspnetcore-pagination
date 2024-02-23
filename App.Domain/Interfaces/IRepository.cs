using App.Domain.Models;

namespace App.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<PageList<T>> GetWithOffsetPagination(int pageNumber, int pageSize);
    }
}