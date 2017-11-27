using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class Customer
	{
		[Key]
		public int CustomerId { get; set; }

		[Required]
		[StringLength(128)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(128)]
		public string LastName { get; set; }

		public string Telephone { get; set; }

		public string Email { get; set; }

		//public virtual IEnumerable<Invoice> Invoices { get; set; }
	}
}
