using ContosoPets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoPets.DataAccess.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Products", "ContosoPets");

			builder.Property(e => e.Id).HasColumnName("ID");
			builder.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
			builder.Property(e => e.Price).HasColumnType("decimal(18,2)").HasDefaultValueSql("((0.00))");

			builder.HasIndex(i => i.Name).HasName("UQX_Product_Name").IsUnique();			
		}
	}
}