using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Api.Commands;
using OrderService.Api.Queries;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator bus;

        public OrderController(IMediator bus)
        {
            this.bus = bus;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateOrderCommand cmd)
        {
            var result = await bus.Send(cmd);
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetOrders([FromQuery] GetOrderDetailsQuery cmd)
        {
            var result = await bus.Send(cmd);
            return new JsonResult(result);
        }
    }
}
