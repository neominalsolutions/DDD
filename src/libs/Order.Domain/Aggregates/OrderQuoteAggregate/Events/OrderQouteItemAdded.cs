using MediatR;
using Order.Domain.Aggregates.OrderQuoteAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderQuoteAggregate.Events
{
  public class OrderQouteItemAdded:INotification
  {
    public  OrderQuote OrderQuote { get; init; }

    public OrderQouteItemAdded(OrderQuote orderQuote)
    {
      this.OrderQuote = orderQuote;
    }


  }
}
