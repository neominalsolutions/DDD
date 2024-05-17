using Order.Domain.SeedWork;
using Order.Domain.Shared;

namespace Order.Domain.Aggregates.OrderAggregate.Entities
{
    public class PurchaseOrderItem:Entity
    {
        public PurchaseOrderItem() { }

        public PurchaseOrderItem(string code, Quantity quantity, Money listPrice, string quoteItemId)
        {
            this.Code = code;
            Quantity = quantity;
            ListPrice = listPrice;
            this.QuoteItemId = quoteItemId;
        }

        public Money ListPrice { get; set; }
        public Quantity Quantity { get; set; }
        public string Code { get; init; }
        public string QuoteItemId { get; init; }
    }
}