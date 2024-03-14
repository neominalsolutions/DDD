using MediatR;
using Order.Domain.Aggregates.OrderQuoteAggregate.Events;
using Order.Domain.Aggregates.OrderQuoteAggregate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderQuoteAggregate.Handlers
{
  public class OrderItemAddedHandler : INotificationHandler<OrderQouteItemAdded>
  {
    private readonly RequestQuoteApprovalService requestQuoteApprovalService;

    public OrderItemAddedHandler(RequestQuoteApprovalService requestQuoteApprovalService)
    {
      this.requestQuoteApprovalService = requestQuoteApprovalService;
    }

    public async Task Handle(OrderQouteItemAdded notification, CancellationToken cancellationToken)
    {
      this.requestQuoteApprovalService.CheckApproval(notification.OrderQuote);
    }
  }
}
