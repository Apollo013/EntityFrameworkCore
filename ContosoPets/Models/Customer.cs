using System.Collections.Generic;

namespace ContosoPets.Models 
{
	public class Customer : BaseEntity 
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}