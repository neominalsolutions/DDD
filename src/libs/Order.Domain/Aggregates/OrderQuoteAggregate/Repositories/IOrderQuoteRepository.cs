using Order.Domain.Aggregates.OrderQuoteAggregate.Entities;
using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderQuoteAggregate.Repositories
{
  public interface IOrderQuoteRepository:IRepository<OrderQuote>
  {
  }
}
