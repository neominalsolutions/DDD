using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Commands.OrderRequests
{
  public class OrderRequestCreateCommand:IRequest
  {
    public decimal BudgetAmount { get; set; }
    public string Currency { get; set; }
    public List<OrderRequestItemDto> RequestItems { get; set; }

  }

  public class OrderRequestItemDto
  {
    public int Quantity { get; set; }

    public string Unit { get; set; }
    public string Code { get; set; }
  }
}
