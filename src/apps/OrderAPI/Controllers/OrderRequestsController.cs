using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Features.Commands.OrderRequests;
using Order.Domain.Aggregates.OrderAggregate.Entities;
using Order.Domain.Aggregates.OrderQuoteAggregate.Events;
using Order.Domain.SeedWork;

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

      var order = PurchaseOrder.Create("", "", new LinkedList<PurchaseOrderItem>());
      // order.AddEvent(new OrderQuoteApproved());


      return NoContent();
    }
  }
}
