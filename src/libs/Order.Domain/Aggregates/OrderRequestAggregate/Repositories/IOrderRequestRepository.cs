using Order.Domain.Aggregates.OrderRequestAggregate.Entities;
using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderRequestAggregate.Repositories
{
  public interface IOrderRequestRepository:IRepository<OrderRequest>
  {
  }
}
