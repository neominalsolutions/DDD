using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Aggregates.OrderQuoteAggregate.Entities;

namespace OrderAPI.Data.Config
{
    public class OrderQuoteConfig : IEntityTypeConfiguration<OrderQuote>
    {
        public void Configure(EntityTypeBuilder<OrderQuote> builder)
        {
            builder.HasMany(x=> x.Items);
            builder.OwnsOne(x => x.Status).Property(x => x.Name).HasColumnName("Status_Name");
            builder.OwnsOne(x => x.Status).Property(x => x.Id).HasColumnName("Status_Value");

        }
    }
}
