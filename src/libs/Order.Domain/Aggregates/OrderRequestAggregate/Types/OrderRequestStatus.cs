using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderRequestAggregate.Types
{
    public class OrderRequestStatus : Enumeration
    {
        public static OrderRequestStatus Pending => new OrderRequestStatus(100, "Pending");
        public static OrderRequestStatus Approved => new OrderRequestStatus(200,"Approved");
        public static OrderRequestStatus Rejected => new OrderRequestStatus(600, "Rejected");
  
        public OrderRequestStatus(int id, string name) : base(id, name)
        {
        }
    }
}
