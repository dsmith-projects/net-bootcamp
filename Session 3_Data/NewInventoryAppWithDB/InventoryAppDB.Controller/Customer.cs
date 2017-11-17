using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppDB.Controller
{
	public class Customer
	{
		[Key]
		public int Customer_id { get; set; }
		[Required]
		[StringLength(128)]
		public string First_name { get; set; }
		[Required]
		[StringLength(128)]
		public string Last_name { get; set; }
		public string Telephone { get; set; }
		public string Email { get; set; }
		public virtual List<Product> Products { get; set; }
	}
}
