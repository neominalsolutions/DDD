using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Features.Commands.OrderRequests;

namespace OrderAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrderRequestsController : ControllerBase
  {
    private IMediator mediator;

    public OrderRequestsController(IMediator mediator)
    {
      this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderRequest([FromBody] OrderRequestCreateCommand request)
    {
      await this.mediator.Send(request);

      return Created("","");
    }


    [HttpPut("approve")]
    public async Task<IActionResult> ApproveOrderRequest([FromBody] ApproveOrderRequestCommand request)
    {
      await this.mediator.Send(request);

      return NoContent();
    }
  }
}
