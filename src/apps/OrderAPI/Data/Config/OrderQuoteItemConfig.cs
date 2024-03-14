using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Aggregates.OrderQuoteAggregate.Entities;

namespace OrderAPI.Data.Config
{
    public class OrderQuoteItemConfig : IEntityTypeConfiguration<OrderQuoteItem>
    {
        public void Configure(EntityTypeBuilder<OrderQuoteItem> builder)
        {
            builder.OwnsOne(x => x.ListPrice).Property(x => x.Amount).HasColumnName("ListPrice");
            builder.OwnsOne(x => x.ListPrice).Property(x => x.Currency).HasColumnName("Currency");


            builder.OwnsOne(x => x.Quantity).Property(x => x.Value).HasColumnName("Quantity");
            builder.OwnsOne(x => x.Quantity).Property(x => x.Unit).HasColumnName("Unit");
        }
    }
}
