using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Order.Domain.SeedWork;
using System.Security.Principal;

namespace OrderAPI.Data
{
    public static class MediatorExtension
    {
        public static void DispathEvents(this IMediator mediator, DbContext context)
        {
            var entities = context.ChangeTracker
                 .Entries<AggregateRoot>()
            .Where(x => x.Entity.events != null && x.Entity.events.Any());



            var entityEntries = entities as EntityEntry<AggregateRoot>[] ?? entities.ToArray();
            var domainEvents = entityEntries
                .SelectMany(x => x.Entity.events)
                .ToList();

            entityEntries.ToList().ForEach(entity => entity.Entity.ClearEvents());

            foreach (INotification domainEvent in domainEvents) { 
                
                mediator.Publish(domainEvent).GetAwaiter().GetResult();   
             }

        }
    }
}
