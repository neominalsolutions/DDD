using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Aggregates.OrderAggregate.Entities;
using Order.Domain.Aggregates.OrderQuoteAggregate.Entities;
using Order.Domain.Aggregates.OrderRequestAggregate.Entities;
using OrderAPI.Data.Config;

namespace OrderAPI.Data
{
    public class OrderContext:DbContext
    {
        private IMediator mediator;

        public OrderContext(DbContextOptions<OrderContext> opt, IMediator mediator):base(opt)
        {
               this.mediator = mediator; 
        }

        public DbSet<OrderRequest> OrderRequests { get; set; }
        public DbSet<OrderQuote> OrderQuoutes { get; set; }

        public DbSet<Order.Domain.Aggregates.OrderAggregate.Entities.Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderRequestConfig());
            modelBuilder.ApplyConfiguration(new OrderRequestItemConfig());

            modelBuilder.ApplyConfiguration(new OrderQuoteConfig());
            modelBuilder.ApplyConfiguration(new OrderQuoteItemConfig());

            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderItemConfig());
       

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            this.mediator.DispathEvents(this);

            return base.SaveChanges();
        }
    }
}
