using MediatR;
using Order.Domain.Aggregates.OrderQuoteAggregate.Services;
using Order.Domain.Aggregates.OrderRequestAggregate.Entities;
using Order.Domain.Aggregates.OrderRequestAggregate.Repositories;
using Order.Domain.SeedWork;
using Order.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Commands.OrderRequests
{
  // bu karmandaki servislerin göre doğru katmanlara doğru bir şekilde yönelendirme yapmak işin koordinasyonunu sağlamak.
  public class CreateOrderRequestCommandHandler : IRequestHandler<OrderRequestCreateCommand>
  {
    private IUnitOfWork unitOfWork;
    private IOrderRequestRepository orderRequestRepository;

    public CreateOrderRequestCommandHandler(IUnitOfWork unitOfWork, IOrderRequestRepository orderRequestRepository)
    {
      this.unitOfWork = unitOfWork;
      this.orderRequestRepository = orderRequestRepository;
    }

    public async Task Handle(OrderRequestCreateCommand request, CancellationToken cancellationToken)
    {
      // Domaim katmanına dtodan gelen request gönderilir ve veri tabanına kayıt işlemleri, ıntegration event fırslatma gibi kodlar yönetilir.

      var orderRequest = OrderRequest.Create(new Money(request.BudgetAmount, request.Currency));

      foreach (var item in request.RequestItems)
      {
        orderRequest.AddItem(item.Code, new Quantity(item.Quantity, item.Unit));
      }

      orderRequestRepository.Create(orderRequest);
      // Integration Event ile başka microservice bildirim gönder.

      unitOfWork.Save();
    }
  }
}
