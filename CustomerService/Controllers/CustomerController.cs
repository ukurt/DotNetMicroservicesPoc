using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Api.Queries;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator bus;

        public CustomerController(IMediator bus)
        {
            this.bus = bus;
        }


        // GET api/values
        [HttpGet]
        public async Task<ActionResult> GetByCode([FromQuery] FindCustomerQuery customerQuery)
        {
            var result = await bus.Send(customerQuery);
            return new JsonResult(result);
        }
    }
}
