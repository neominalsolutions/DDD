using Order.Domain.Aggregates.OrderRequestAggregate.Entities;
using Order.Domain.Aggregates.OrderRequestAggregate.Repositories;
using Order.Domain.SeedWork;

namespace OrderAPI.Data.Repositories
{
  public class EFOrderRequestRepository : IOrderRequestRepository
  {

    private readonly OrderContext orderContext;

    public EFOrderRequestRepository(OrderContext orderContext)
    {
      this.orderContext = orderContext;
    }

    public void Create(OrderRequest root)
    {
      this.orderContext.OrderRequests.Add(root);
    }

    public void Delete(string Id)
    {
      throw new NotImplementedException();
    }

    public List<OrderRequest> FindAll()
    {
      throw new NotImplementedException();
    }

    public OrderRequest FindById(string Id)
    {
      var entity = this.orderContext.OrderRequests.Find(Id);

      if (entity is null)
        throw new Exception("Entity Not Found");

      return entity;
    }

    public void Update(AggregateRoot root)
    {
      throw new NotImplementedException();
    }

    public void Update(OrderRequest root)
    {
      throw new NotImplementedException();
    }
  }
}
