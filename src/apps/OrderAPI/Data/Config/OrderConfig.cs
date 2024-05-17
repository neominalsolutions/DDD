using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderAPI.Data.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order.Domain.Aggregates.OrderAggregate.Entities.PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<Order.Domain.Aggregates.OrderAggregate.Entities.PurchaseOrder> builder)
        {
            builder.HasMany(x => x.Items);
            builder.OwnsOne(x => x.Status).Property(x => x.Name).HasColumnName("Status_Name");
            builder.OwnsOne(x => x.Status).Property(x => x.Id).HasColumnName("Status_Value");

           
 
        }
    }
}
