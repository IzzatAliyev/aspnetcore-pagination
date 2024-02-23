using App.Api.Dtos;
using App.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController(IProductService productService, IMapper mapper) : ControllerBase
    {
        private readonly IProductService productService = productService;
        private readonly IMapper mapper = mapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWithPagination(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
                return BadRequest($"{nameof(pageNumber)} and {nameof(pageSize)} size must be greater than 0.");

            var pagedProducts = await this.productService.GetWithOffsetPagination(pageNumber, pageSize);

            var pagedProductsDto = this.mapper.Map<PageListDto<ProductResponseDto>>(pagedProducts);

            return Ok(pagedProductsDto);
        }
    }
}