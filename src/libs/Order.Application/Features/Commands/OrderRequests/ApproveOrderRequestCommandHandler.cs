using MediatR;
using Order.Domain.Aggregates.OrderRequestAggregate.Repositories;
using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Commands.OrderRequests
{
  public class ApproveOrderRequestCommandHandler : IRequestHandler<ApproveOrderRequestCommand>
  {
    private readonly IOrderRequestRepository orderRequestRepository;
    private readonly IUnitOfWork unitOfWork;

    public ApproveOrderRequestCommandHandler(IOrderRequestRepository orderRequestRepository, IUnitOfWork unitOfWork)
    {
      this.orderRequestRepository = orderRequestRepository;
      this.unitOfWork = unitOfWork;
    }

    public async Task Handle(ApproveOrderRequestCommand request, CancellationToken cancellationToken)
    {
      var req = this.orderRequestRepository.FindById(request.RequestId);

      if(req is null)
      {
        throw new Exception("Resource Not Found");
      }

      req.Approve();

      this.unitOfWork.Save();

    }
  }
}
