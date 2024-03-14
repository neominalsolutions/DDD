using MediatR;
using Order.Domain.Aggregates.OrderQuoteAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderQuoteAggregate.Events
{
  public class OrderQuoteItemAdded:INotification
  {
    public  OrderQuote OrderQuote { get; init; }

    public OrderQuoteItemAdded(OrderQuote orderQuote)
    {
      this.OrderQuote = orderQuote;
    }


  }
}
