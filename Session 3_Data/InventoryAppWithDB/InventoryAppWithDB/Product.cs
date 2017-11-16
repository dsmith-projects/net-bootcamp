using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppWithDB
{
   public class Product
	{
		[Key]
        public int Product_id { get; set; }
		[Required]
		[StringLength(200)]
		public string Product_name { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int Avail_quantity { get; set; }
		[Required]
		public string Category { get; set; }
		public virtual List<Customer> Customers { get; set; }
    }
}
