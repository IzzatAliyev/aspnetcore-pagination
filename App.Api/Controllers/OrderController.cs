using App.Api.Dtos;
using App.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController(IOrderService orderService, IMapper mapper) : ControllerBase
    {
        private readonly IOrderService orderService = orderService;
        private readonly IMapper mapper = mapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWithPagination(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
                return BadRequest($"{nameof(pageNumber)} and {nameof(pageSize)} size must be greater than 0.");

            var pagedOrders = await this.orderService.GetWithOffsetPagination(pageNumber, pageSize);

            var pagedOrdersDto = this.mapper.Map<PageListDto<OrderResponseDto>>(pagedOrders);

            return Ok(pagedOrdersDto);
        }
    }
}