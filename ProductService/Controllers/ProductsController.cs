using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Api.Queries;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET api/products/{code}
        [HttpGet]
        public async Task<ActionResult> GetByCode([FromQuery] FindProductByIdQuery cmd)
        {
            var result = await mediator.Send(cmd);                        
            return new JsonResult(result);
        }
    }    
}
