using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Aggregates.OrderQuoteAggregate.Entities;
using Order.Domain.Aggregates.OrderRequestAggregate.Entities;
using Order.Domain.Aggregates.OrderRequestAggregate.Types;
using Order.Domain.SeedWork;
using Order.Domain.Shared;
using OrderAPI.Data;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrderContext _orderContext;

        public OrdersController(OrderContext orderContext)
        {
                _orderContext = orderContext;
        }

        [HttpGet]
        public IActionResult Test()
        {
          

            // 1. aşama
            var request = OrderRequest.Create(new Money(10000,"TL"));
            request.AddItem("P-01",new Quantity(1,"pieces"));
            request.AddItem("P-02", new Quantity(4, "boxes"));
            request.AddItem("P-03", new Quantity(3, "kg"));

            _orderContext.OrderRequests.Add(request);
            request.Approve();

            _orderContext.SaveChanges();



            var quote = new OrderQuote(request.Id);

            Random rdm = new Random();
            

            foreach (var item in request.Items)
            {
                quote.AddItem(item.Code,item.Quantity,new Money(rdm.Next(0,1000),"TL"),request.Id);
            }

            _orderContext.OrderQuoutes.Add(quote);

            quote.TransformAsOrder();

            _orderContext.SaveChanges();




            return Ok();
    
        }
    }
}
