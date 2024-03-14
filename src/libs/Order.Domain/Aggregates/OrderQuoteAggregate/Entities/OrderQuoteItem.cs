using Order.Domain.SeedWork;
using Order.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderQuoteAggregate.Entities
{
    public class OrderQuoteItem:Entity
    {
        public OrderQuoteItem()
        {
            
        }

        public OrderQuoteItem(string code, Quantity quantity, Money listPrice, string requestItemId)
        {
            this.Code = code;
            Quantity = quantity;
            ListPrice = listPrice;
            this.RequestItemId = requestItemId;
        }

        public Money ListPrice { get; set; }
        public Quantity Quantity { get; set; }
        public string Code { get; init; }
        public string RequestItemId { get; init; }

    }
}
