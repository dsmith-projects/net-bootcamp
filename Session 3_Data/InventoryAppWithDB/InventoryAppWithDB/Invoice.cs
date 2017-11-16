using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppWithDB
{
    public class Invoice
    {
		[Key, Column(Order = 0)]
		public string Customer_id { get; set; }
		[Key, Column(Order = 1)]
		public int Product_id { get; set; }
		[Required]
        public int Quantity { get; set; }
		[Required]
        public DateTime Purchase_date { get; set; }
		public Customer Customer { get; set; }
		public List<Product> Products { get; set; }
	}
}
