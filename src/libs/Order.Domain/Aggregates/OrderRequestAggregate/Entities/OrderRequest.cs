
using Order.Domain.Aggregates.OrderAggregate.Types;
using Order.Domain.Aggregates.OrderRequestAggregate.Exceptions;
using Order.Domain.Aggregates.OrderRequestAggregate.Types;
using Order.Domain.SeedWork;
using Order.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderRequestAggregate.Entities
{
    public class OrderRequest:AggregateRoot
    {
        public Money Budget { get; init; }
        public DateTime RequestedAt { get; init; }

        private List<OrderRequestItem> items = new List<OrderRequestItem>();

        public IReadOnlyList<OrderRequestItem> Items => items;

        public string? RejectedReason { get; private set; }
        
        public  OrderRequestStatus Status { get; private set;}

        public OrderRequest()
        {
            
        }
        private OrderRequest(Money budget)
        {
            Status = OrderRequestStatus.Pending;
            RequestedAt = DateTime.UtcNow;
            Budget = budget;
        }

        public static OrderRequest Create(Money budget)
        {
            return new OrderRequest(budget);
        }

        public void AddItem(string code, Quantity quantity)
        {
            // aggregate ilgilendiren aggregate içinde halledebileceğimiz kurallar burayı yazılabilir.
            if(items.Count > 5)
            {
                throw new OrderItemRequestLimitException();
            }

            items.Add(new OrderRequestItem(code,quantity, Id));
        }

        public void Approve()
        {
            // Eğer state değişimi yaparken kendi aggregate sınırımız dışına çıkmıyorsak event fırlatmaya gerek yok.
            this.Status = OrderRequestStatus.Approved;

        }

        public void Reject(string rejectedReason)
        {
            RejectedReason = rejectedReason;
            this.Status = OrderRequestStatus.Rejected;
        }

    }
}
