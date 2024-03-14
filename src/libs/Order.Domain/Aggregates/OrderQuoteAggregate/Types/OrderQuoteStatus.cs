using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderQuoteAggregate.Types
{
    public class OrderQuoteStatus : Enumeration
    {
        public static OrderQuoteStatus Pending => new OrderQuoteStatus(100, "Pending");
        public static OrderQuoteStatus Approved => new OrderQuoteStatus(200, "Approved");
        public static OrderQuoteStatus Rejected => new OrderQuoteStatus(600, "Rejected");

        public OrderQuoteStatus(int id, string name) : base(id, name)
        {
        }
    }
}
