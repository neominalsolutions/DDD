using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.SeedWork
{
  public abstract class Entity
  {
    public string Id { get; init; }

    protected Entity()
    {
      Id = Guid.NewGuid().ToString();
    }

    
  }
}
