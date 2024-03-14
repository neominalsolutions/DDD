using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Aggregates.OrderRequestAggregate.Entities;

namespace OrderAPI.Data.Config
{
    public class OrderRequestConfig : IEntityTypeConfiguration<OrderRequest>
    {
        public void Configure(EntityTypeBuilder<OrderRequest> builder)
        {
            builder.HasMany(x=> x.Items);
            builder.OwnsOne(x=> x.Budget).Property(x=> x.Amount).HasColumnName("Budget_Amount");
            builder.OwnsOne(x => x.Budget).Property(x => x.Currency).HasColumnName("Budget_Currecy");


            builder.OwnsOne(x => x.Status).Property(x => x.Name).HasColumnName("Status_Name");
            builder.OwnsOne(x => x.Status).Property(x => x.Id).HasColumnName("Status_Value");
        }
    }
}
