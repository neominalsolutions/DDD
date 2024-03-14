using Order.Domain.SeedWork;
using Order.Domain.Shared;

namespace Order.Domain.Aggregates.OrderRequestAggregate.Entities
{
    // Child nesneler Entity olarak işaretleniyor
    public class OrderRequestItem:Entity
    {
        public OrderRequestItem()
        {
                
        }
        public OrderRequestItem(string code, Quantity quantity, string orderRequestId)
        {
            Code = code;
            Quantity = quantity;
            OrderRequestId = orderRequestId;
        }

        public string Code { get; private set; }
        public Quantity Quantity { get; private set; }

        public string OrderRequestId { get; init; }

        public void SetCode(string code)
        {
            Code = code;
            
        }
    }
}