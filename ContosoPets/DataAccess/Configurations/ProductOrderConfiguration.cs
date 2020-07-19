using ContosoPets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoPets.DataAccess.Configurations
{
	public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
	{
		public void Configure(EntityTypeBuilder<ProductOrder> builder)
		{
			builder.ToTable("ProductOrders", "ContosoPets");

			builder.Property(e => e.Id).HasColumnName("ID");
			builder.Property(e => e.Quantity).IsRequired();
			builder.Property(e => e.ProductId).HasColumnName("ProductID");
			builder.Property(e => e.OrderId).HasColumnName("OrderID");

			builder.HasOne(p => p.Order)
				.WithMany(c => c.ProductOrders)
				.HasForeignKey(k => k.OrderId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_ProductOrder_Order");

			builder.HasOne(p => p.Product)
				.WithMany(c => c.ProductOrders)
				.HasForeignKey(k => k.ProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_ProductOrder_Product");
		}
	}
}