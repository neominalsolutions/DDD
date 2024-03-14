using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Commands.OrderRequests
{
  public class ApproveOrderRequestCommand:IRequest
  {
    public string RequestId { get; set; }

  }
}
