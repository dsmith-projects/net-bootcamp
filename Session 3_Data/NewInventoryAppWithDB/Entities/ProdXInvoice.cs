using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class ProdXInvoice
	{
		[Key]
		public int ProdXInvoiceId { get; set; }

		[ForeignKey("Invoice")]
		public int InvoiceId { get; set; }

		[ForeignKey("Product")]
		public int ProductId { get; set; }

		[Required]
		public int Quantity { get; set; }

		public virtual Invoice Invoice { get; set; }

		public virtual Product Product { get; set; }
	}
}
