using App.Domain.Interfaces;
using App.Domain.Models;

namespace App.Domain.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        private readonly IProductRepository productRepository = productRepository;

        public Task<PageList<Product>> GetWithOffsetPagination(int pageNumber, int pageSize)
        {
            return this.productRepository.GetWithOffsetPagination(pageNumber, pageSize);
        }
    }
}