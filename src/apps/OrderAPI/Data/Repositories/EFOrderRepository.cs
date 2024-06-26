﻿using Order.Domain.Aggregates.OrderAggregate.Entities;
using Order.Domain.Aggregates.OrderAggregate.Repositories;
using Order.Domain.SeedWork;

namespace OrderAPI.Data.Repositories
{
  public class EFOrderRepository : IOrderRepository
  {
    private readonly OrderContext orderContext;

    public EFOrderRepository(OrderContext orderContext)
    {
      this.orderContext = orderContext;
    }

    public void Create(Order.Domain.Aggregates.OrderAggregate.Entities.PurchaseOrder root)
    {
      this.orderContext.Orders.Add(root);
    }

    public void Delete(string Id)
    {
      throw new NotImplementedException();
    }

    public List<Order.Domain.Aggregates.OrderAggregate.Entities.PurchaseOrder> FindAll()
    {
      throw new NotImplementedException();
    }

    public Order.Domain.Aggregates.OrderAggregate.Entities.PurchaseOrder FindById(string Id)
    {
      throw new NotImplementedException();
    }

    public void Update(AggregateRoot root)
    {
      throw new NotImplementedException();
    }

    public void Update(Order.Domain.Aggregates.OrderAggregate.Entities.PurchaseOrder root)
    {
      throw new NotImplementedException();
    }
  }
}
