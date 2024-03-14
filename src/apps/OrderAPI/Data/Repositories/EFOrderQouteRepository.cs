using Order.Domain.Aggregates.OrderQuoteAggregate.Entities;
using Order.Domain.Aggregates.OrderQuoteAggregate.Repositories;
using Order.Domain.SeedWork;

namespace OrderAPI.Data.Repositories
{
  public class EFOrderQouteRepository : IOrderQuoteRepository
  {
    private readonly OrderContext orderContext;

    public EFOrderQouteRepository(OrderContext orderContext)
    {
      this.orderContext = orderContext;
    }

    public void Create(OrderQuote root)
    {
      this.orderContext.OrderQuotes.Add(root);
    }

    public void Delete(string Id)
    {
      throw new NotImplementedException();
    }

    public List<OrderQuote> FindAll()
    {
      throw new NotImplementedException();
    }

    public OrderQuote FindById(string Id)
    {
      throw new NotImplementedException();
    }

    public void Update(AggregateRoot root)
    {
      throw new NotImplementedException();
    }

    public void Update(OrderQuote root)
    {
      throw new NotImplementedException();
    }
  }
}
