using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Aggregates.OrderRequestAggregate.Entities;

namespace OrderAPI.Data.Config
{
    public class OrderRequestItemConfig : IEntityTypeConfiguration<OrderRequestItem>
    {
        public void Configure(EntityTypeBuilder<OrderRequestItem> builder)
        {
            builder.OwnsOne(x => x.Quantity).Property(x => x.Value).HasColumnName("Quantity");
            builder.OwnsOne(x => x.Quantity).Property(x => x.Unit).HasColumnName("Unit");
        }
    }
}
