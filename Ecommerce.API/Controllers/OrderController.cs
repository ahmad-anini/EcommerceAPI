using AutoMapper;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Entities.DTO;
using Ecommerce.Core.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork<Orders> unitOfWork;
        private readonly IMapper mapper;

        public OrderController(IUnitOfWork<Orders> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet("ByUser/{UserId}")]
        public async Task<ActionResult> GetOrdersByUserId(int UserId)
        {
            var orders = await unitOfWork.OrderRepository.GetAllOrdersByUserId(UserId);
            var mappedOrders = mapper.Map<List<Orders>, List<OrderDTO>>(orders);
            return Ok(mappedOrders);
        }
    }
}
