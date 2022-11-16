using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rewriter.OrderService;
using rewriter.OrderService.Models;
using rewriter.Services.Models;
using System.Web.Http.Cors;

namespace rewriter.Controllers
{
   [ApiController]
   [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        //private readonly ILogger<OrderController> logger;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }
        [HttpPost("")]
        public async Task<OrderModel> AddOrder(AddOrderModel model)
    {
            var order = await orderService.AddOrder(model);
            return order;
    }
        [Authorize]
        [Route("all")]
        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            var orderds=await orderService.GetOrders();
            return orderds;
        }
        [Authorize(Roles ="Creator")]
        [Route("string")]
        public async Task<string> GetAllOrdersstring()
        {
            var orderds = await orderService.GetOrders();
            return "working";
        }
        [HttpGet]
        public async Task<OrdersResponse> GetOrderForPage([FromQuery] string page,[FromQuery(Name ="topics")] string[] topics, int offset=7)
        {
            var orders = await orderService.GetOrderForPage(page,topics,offset);
            return orders;
        }
        [HttpGet]
        [Authorize(Roles ="Creator")]
        [Route("userId")]
        public async Task<OrdersResponse> GetProductsByUserId([FromQuery] int page,[FromQuery] int userId,int offset=7)
        {
            var orders = await orderService.GetProductsByUserId(page, userId,offset);
            return orders;
        }

        [HttpDelete]
        public async Task DeleteOrder([FromQuery] int id)
        {
            await orderService.DeleteOrder(id);
        }


        [HttpPut]
        public async Task UpdateOrder([FromQuery]   int id,UpdateOrderModel model)
        {
            await orderService.UpdateOrder(id,model);

        }
    }
}
