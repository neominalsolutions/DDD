using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderRequestAggregate.Exceptions
{
    public class OrderItemRequestLimitException:Exception
    {
        public OrderItemRequestLimitException(string message= "En falza 5 adet request item girebiliriz"):base(message)
        {
                
        }
    }
}
