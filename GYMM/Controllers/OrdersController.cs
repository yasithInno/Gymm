using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GYMM.Core.Entities.OrderAggregate;
using GYMM.Core.Interfaces;
using GYMM.Dtos;
using GYMM.Errors;
using GYMM.Extensions;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GYMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseApiController
    {
        private readonly IMapper mapper;
        public IOrderService OrderService { get; }

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            OrderService = orderService;
            this.mapper = mapper;
        }

        [HttpPost(nameof(CreateOrder))]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var user = HttpContext.User.ReteriveEmailFromPrincipal();
            var address = mapper.Map<AddressDto, Address>(orderDto.ShippingToAddress);
            var order = await OrderService.CreateOrderAsync(
                user,
                orderDto.DeliveryMethodId,
                orderDto.basketId,
                address);
            if (order == null)
            {
                return BadRequest(new APIResponce(400, "Something went Wrong"));
            }
            return Ok(order);

        }

        [HttpGet(nameof(GetOrdersForUser))]
        public async Task<ActionResult<Order>> GetOrdersForUser()
        {
            var user = HttpContext.User.ReteriveEmailFromPrincipal();
            var order = await OrderService.GetOrderForUserAsync(user);
            return Ok(order);
        }
        [HttpGet(nameof(GetOrderByUserId))]
        public async Task<ActionResult<Order>> GetOrderByUserId(int userId)
        {
          var user = HttpContext.User.ReteriveEmailFromPrincipal();
          var order = await OrderService.GetOrderByIdAsync(userId,user);
            if (order == null) return BadRequest(new APIResponce(404));
            return order;
        }
        [HttpGet(nameof(GetDeliverMethod))]
        public async Task<ActionResult<DeliveryMethod>> GetDeliverMethod()
        {
            return Ok(OrderService.GetDeliveryMethodAsync());
        }

    }
}
