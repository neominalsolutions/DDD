using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.SeedWork
{
    public abstract class AggregateRoot:Entity
    {
       public readonly List<INotification> events = new List<INotification>();

        public void AddEvent(INotification @event)
        {
            events.Add(@event);
        }

        public void ClearEvents()
        {
            events.Clear();
        }
    }
}
