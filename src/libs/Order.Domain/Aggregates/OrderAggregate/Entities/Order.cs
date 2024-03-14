using Order.Domain.Aggregates.OrderAggregate.Types;
using Order.Domain.Aggregates.OrderRequestAggregate.Exceptions;
using Order.Domain.SeedWork;
using Order.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderAggregate.Entities
{
    public class Order:AggregateRoot
    {
        public string RequestId { get; set; }
        public string QuoteId { get; set; }

        public DateTime OrderedAt { get; init; }

        public OrderStatus Status { get; private set; }

        public ImmutableList<OrderItem> Items {get; private set; }

        public Money TotalAmount
        {
            get
            {
                if (Items.Count() > 0)
                {
                    return new Money(Items.Sum(x => x.ListPrice.Amount), Items.First().ListPrice.Currency);
                }
                else
                {
                    return Money.Zero();
                }
            }
        }

        public Order()
        {
                
        }

        private Order(string requestId, string quoteId,IEnumerable<OrderItem> items) {
            
            Items = items.ToImmutableList();
            Status = OrderStatus.Submitted;
            RequestId = requestId;
            QuoteId = quoteId;
            OrderedAt = DateTime.UtcNow;


        }  

        public static Order Create(string requestId, string quoteId, IEnumerable<OrderItem> items)
        {
            return new Order(requestId, quoteId, items);
        }



    }
}
