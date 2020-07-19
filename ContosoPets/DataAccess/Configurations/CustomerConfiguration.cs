using ContosoPets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoPets.DataAccess.Configurations
{
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.ToTable("Customers", "ContosoPets");

			builder.Property(e => e.Id).HasColumnName("ID");
			builder.Property(e => e.FirstName).IsRequired().HasMaxLength(40).IsUnicode(false);
			builder.Property(e => e.LastName).IsRequired().HasMaxLength(40).IsUnicode(false);
			builder.Property(e => e.Address).HasMaxLength(60).IsUnicode(false);
			builder.Property(e => e.Phone).HasMaxLength(20).IsUnicode(false);

			builder.HasIndex(i => new { i.LastName, i.FirstName }).HasName("IX_Customer_LastName_FirstName").IsUnique(false);			
		}
	}
}