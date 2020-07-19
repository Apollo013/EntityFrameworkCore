using ContosoPets.DataAccess.Configurations;
using ContosoPets.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPets.DataAccess.Contexts
{
	public class ContosoPetsContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductOrder> ProductOrders { get; set; }

		public ContosoPetsContext() {
			ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new CustomerConfiguration());
			builder.ApplyConfiguration(new ProductConfiguration());
			builder.ApplyConfiguration(new OrderConfiguration());
			builder.ApplyConfiguration(new ProductOrderConfiguration());
		}
	}
}