using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00013622.Dtos;
using WAD._00013622.Interfaces;
using WAD._00013622.Models;
using WAD._00013622.Responses;

namespace WAD._00013622.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrdersWithUsersAsync();
            var ordersReadDto = _mapper.Map<IEnumerable<OrderReadDto>>(orders);
            return Ok(ordersReadDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReadDto>> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderByIdWithUserAsync(id);
            if (order == null)
            {
                return NotFound(new BaseResponse { Success = false, Message = "Order not found", Error = "NotFound" });
            }

            var orderReadDto = _mapper.Map<OrderReadDto>(order);
            return Ok(orderReadDto);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CreateOrder(OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);
            await _orderRepository.AddAsync(order);

            return Ok(new BaseResponse { Success = true, Message = "Order added successfully", Error = null });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse>> UpdateOrder(int id, OrderUpdateDto orderUpdateDto)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound(new BaseResponse { Success = false, Message = "Order not found", Error = "NotFound" });
            }

            _mapper.Map(orderUpdateDto, order);
            await _orderRepository.UpdateAsync(order);

            return Ok(new BaseResponse { Success = true, Message = "Order updated successfully", Error = null });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> DeleteOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound(new BaseResponse { Success = false, Message = "Order not found", Error = "NotFound" });
            }

            await _orderRepository.DeleteAsync(id);
            return Ok(new BaseResponse { Success = true, Message = "Order deleted successfully", Error = null });
        }
    }
}
