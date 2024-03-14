using MediatR;
using Order.Domain.Aggregates.OrderQuoteAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderQuoteAggregate.Events
{
    public class OrderQuoteApproved:INotification
    {
        public OrderQuote OrderQuote { get; init; }
        public OrderQuoteApproved(OrderQuote orderQuote)
        {
            OrderQuote = orderQuote;
        }
    }
}
