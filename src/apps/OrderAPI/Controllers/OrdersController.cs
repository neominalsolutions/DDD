using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Aggregates.OrderQuoteAggregate.Entities;
using Order.Domain.Aggregates.OrderQuoteAggregate.Repositories;
using Order.Domain.Aggregates.OrderQuoteAggregate.Services;
using Order.Domain.Aggregates.OrderRequestAggregate.Entities;
using Order.Domain.Aggregates.OrderRequestAggregate.Repositories;
using Order.Domain.Aggregates.OrderRequestAggregate.Types;
using Order.Domain.SeedWork;
using Order.Domain.Shared;
using OrderAPI.Data;
using OrderAPI.Data.Repositories;

namespace OrderAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrdersController : ControllerBase
  {
    private IUnitOfWork unitOfWork;
    private IMediator mediator;
    private RequestQuoteApprovalService approvalService;
    private IOrderRequestRepository orderRequestRepository;
    private IOrderQuoteRepository orderQuoteRepository;

    public OrdersController(IUnitOfWork unitOfWork, IMediator mediator, RequestQuoteApprovalService approvalService, IOrderRequestRepository orderRequestRepository, IOrderQuoteRepository orderQuoteRepository)
    {
      this.unitOfWork = unitOfWork;
      this.mediator = mediator;
      this.approvalService = approvalService;
      this.orderRequestRepository = orderRequestRepository;
      this.orderQuoteRepository = orderQuoteRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Test()
    {


      // 1. aşama
      var request = OrderRequest.Create(new Money(1000, "TL"));
      request.AddItem("P-01", new Quantity(1, "pieces"));
      request.AddItem("P-02", new Quantity(4, "boxes"));
      request.AddItem("P-03", new Quantity(3, "kg"));

      orderRequestRepository.Create(request);
      request.Approve();

      unitOfWork.Save();



      var quote = new OrderQuote(request.Id); // aggregateroot


      Random rdm = new Random();
      Random rdmQuantity = new Random();


      foreach (var item in request.Items)
      {
        quote.AddItem(item.Code, new Quantity(rdmQuantity.Next(1, 6),"kg"), new Money(rdm.Next(900, 1000), "TL"), request.Id, approvalService);
      }

      orderQuoteRepository.Create(quote);

      quote.TransformAsOrder();
      unitOfWork.Save();

      // manuel publish EF olmadığı durumda manuel olarak iş bitince gönderimle save işlemi öncesi çalıştırılmalıdır.
      //foreach (INotification @event in quote.events)
      //{
      //  await this.mediator.Publish(@event);
      //}







      return Ok();

    }
  }
}
