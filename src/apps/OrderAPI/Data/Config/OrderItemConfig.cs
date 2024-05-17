using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Aggregates.OrderAggregate.Entities;

namespace OrderAPI.Data.Config
{
    public class OrderItemConfig : IEntityTypeConfiguration<PurchaseOrderItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderItem> builder)
        {
            builder.OwnsOne(x => x.ListPrice).Property(x => x.Amount).HasColumnName("ListPrice");
            builder.OwnsOne(x => x.ListPrice).Property(x => x.Currency).HasColumnName("Currency");

            builder.OwnsOne(x => x.Quantity).Property(x => x.Value).HasColumnName("Quantity");
            builder.OwnsOne(x => x.Quantity).Property(x => x.Unit).HasColumnName("Unit");
        }
    }
}
