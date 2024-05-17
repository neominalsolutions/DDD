using Order.Domain.SeedWork;

namespace OrderAPI.Data.Repositories
{
  public class OrderUnitOfWork : IUnitOfWork
  {
    private readonly OrderContext orderContext;

    public OrderUnitOfWork(OrderContext orderContext)
    {
      this.orderContext = orderContext;
    }

    public void Commit()
    {
      this.orderContext.SaveChanges();
    }
  }
}
