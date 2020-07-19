using System.Collections.Generic;

namespace ContosoPets.Models
{
	public class Product : BaseEntity 
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public ICollection<ProductOrder> ProductOrders { get; set; }
	}
}