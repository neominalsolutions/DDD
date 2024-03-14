using Order.Domain.Aggregates.OrderRequestAggregate.Types;
using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderAggregate.Types
{
    public class OrderStatus: Enumeration
    {
        public static OrderStatus Submitted => new OrderStatus(100, "Submitted");
        public static OrderStatus Invoiced => new OrderStatus(200, "Invoiced");
        public static OrderStatus Shipped => new OrderStatus(600, "Shipped");

        public OrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}
