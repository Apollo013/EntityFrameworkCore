using System;
using System.Collections.Generic;

namespace ContosoPets.Models 
{
	public class Order : BaseEntity  
	{
		public DateTime OrderPlaced { get; set; }
		public DateTime? OrderFulfilled { get; set; }
		public int CustomerId { get; set; }

		public Customer Customer { get; set; }
		public ICollection<ProductOrder> ProductOrders { get; set; }
	}
}