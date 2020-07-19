using ContosoPets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoPets.DataAccess.Configurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Orders", "ContosoPets");

			builder.Property(e => e.Id).HasColumnName("ID");
			builder.Property(e => e.OrderPlaced).IsRequired().HasColumnName("OrderPlacedDTM").HasColumnType("datetime").HasDefaultValueSql("(getdate())");
			builder.Property(e => e.OrderFulfilled).HasColumnName("OrderFulfilledDTM").HasColumnType("datetime");
			builder.Property(e => e.CustomerId).HasColumnName("CustomerID");

			builder.HasOne(p => p.Customer)
				.WithMany(c => c.Orders)
				.HasForeignKey(k => k.CustomerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Order_Customer");
		}
	}
}