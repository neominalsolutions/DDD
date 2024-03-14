using Order.Domain.Aggregates.OrderQuoteAggregate.Events;
using Order.Domain.Aggregates.OrderQuoteAggregate.Services;
using Order.Domain.Aggregates.OrderQuoteAggregate.Types;
using Order.Domain.SeedWork;
using Order.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderQuoteAggregate.Entities
{
  public class OrderQuote : AggregateRoot
  {
    private readonly List<OrderQuoteItem> _items = new List<OrderQuoteItem>();

    public IReadOnlyList<OrderQuoteItem> Items => _items;

    public DateTime QuotedAt { get; init; }

    public Money TotalAmount
    {
      get
      {
        if (_items.Count() > 0)
        {
          return new Money(_items.Sum(x => x.ListPrice.Amount), _items.First().ListPrice.Currency);
        }
        else
        {
          return Money.Zero();
        }
      }
    }

    public string OrderRequestId { get; init; }


    public OrderQuoteStatus Status { get; private set; }

    public OrderQuote()
    {

    }

    //private RequestQuoteApprovalService RequestQuoteApprovalService;

    //    public OrderQuote(string orderRequestId, RequestQuoteApprovalService requestQuoteApprovalService)
    //    {
    //        QuotedAt = DateTime.Now;
    //        Status = OrderQuoteStatus.Pending;
    //        OrderRequestId = orderRequestId;
    //      this.RequestQuoteApprovalService = requestQuoteApprovalService;
    //    }


    public OrderQuote(string orderRequestId)
    {
      QuotedAt = DateTime.Now;
      Status = OrderQuoteStatus.Pending;
      OrderRequestId = orderRequestId;
    }

    // bir entity içersinden bir servisin enjecte edilerek bussiness kuralının bir domain servis üzerinden kontrol edilmesi durumuna double dispatch denir. 
    public void AddItem(string code, Quantity quantity, Money listPrice, string requestItemId, RequestQuoteApprovalService requestQuoteApprovalService = null)
    {
      // Domain service olucak
      // item sayısı eksik ise bu durumda teklif bütçenin altında bir rakam olmalıdır
      // teklif bütçenin üstüne ancak her bir request item teklife yansıtıldığı zaman düşünülebilir, ama bu durumda bütçenin %10 aşamaz.
      _items.Add(new OrderQuoteItem(code, quantity, listPrice, requestItemId));

      // 1.yöntem
      requestQuoteApprovalService.CheckApproval(this);

      // 2.yöntem
      //var @event = new OrderQouteItemAdded(this);
      //AddEvent(@event); // logic event üzerinden işletilsin.


    }

    public void TransformAsOrder()
    {
      Status = OrderQuoteStatus.Approved;
      // Bir domain event fırlatacağız
      // OrderQuoteApproved Domain Event
      // Bu event order auto generate edecek
      // farklı bir aggregate geçiş var.
      var @event = new OrderQuoteApproved(this);
      AddEvent(@event);
    }

    public void Rejected(string reason)
    {
      Status = OrderQuoteStatus.Rejected;
    }

  }
}
