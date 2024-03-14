using MediatR;
using Order.Domain.Aggregates.OrderAggregate.Entities;
using Order.Domain.Aggregates.OrderQuoteAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderQuoteAggregate.Handlers
{
    // Domain event execution işlemi
    public class OrderQuoteApprovedHandler : INotificationHandler<OrderQuoteApproved>
    {
        

        public Task Handle(OrderQuoteApproved notification, CancellationToken cancellationToken)
        {
            // Generate Order. And Save

            var items = notification.OrderQuote.Items.Select(a=> new OrderItem(a.Code,a.Quantity,a.ListPrice,notification.OrderQuote.Id));

            var order = Order.Domain.Aggregates.OrderAggregate.Entities.Order.Create(notification.OrderQuote.OrderRequestId,notification.OrderQuote.Id, items);

            // orderRepo.Create(order);
            // Save

           return  Task.CompletedTask;
        }
    }
}
