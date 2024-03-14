using Order.Domain.Aggregates.OrderQuoteAggregate.Entities;
using Order.Domain.Aggregates.OrderQuoteAggregate.Repositories;
using Order.Domain.Aggregates.OrderRequestAggregate.Repositories;
using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Aggregates.OrderQuoteAggregate.Services
{
  public class RequestQuoteApprovalService
  {
    private readonly IOrderRequestRepository orderRequestRepository;
    private readonly IUnitOfWork unitOfWork;

    public RequestQuoteApprovalService(IOrderRequestRepository orderRequestRepository, IUnitOfWork unitOfWork)
    {
      this.orderRequestRepository = orderRequestRepository;
      this.unitOfWork = unitOfWork;
    }

    public void CheckApproval(OrderQuote orderQuote)
    {
      var request = this.orderRequestRepository.FindById(orderQuote.OrderRequestId);

      bool IsMatch = true;
      int matchCount = 0;
      var quantityIsDifferent = false;

      foreach (var item in request.Items)
      {
        if(orderQuote.Items.Any(x => x.Code == item.Code))
        {
          matchCount++;
        }     
      }

      foreach (var item in request.Items)
      {
         var entity = orderQuote.Items.FirstOrDefault(x => x.Code == item.Code);
   
        if (entity == null)
        {
          IsMatch = false;
          break;
        }
        else
        {
          quantityIsDifferent = entity.Quantity.Value != item.Quantity.Value;

          if (!quantityIsDifferent)
          {
            IsMatch = false;
            break;
          }
        }

      }



      if (!IsMatch)
      {
        if(matchCount < request.Items.Count() && orderQuote.TotalAmount.Amount > request.Budget.Amount )
        {
          throw new Exception("Listede eksik itemlar var. Bütçe aşılamaz");
        }
      
      }
      else
      {
        if((orderQuote.TotalAmount.Amount * 1.10M) >= request.Budget.Amount)
        {
          throw new Exception("Bütçenin %10 üstüne çıkıldı");
        }
      }
    }
  }
}
