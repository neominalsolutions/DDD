using Order.Domain.Aggregates.OrderQuoteAggregate.Entities;
using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderAggregate.Repositories
{
  public interface IOrderRepository : IRepository<Order.Domain.Aggregates.OrderAggregate.Entities.Order>
  {
  }
}
