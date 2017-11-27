using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
	public class Invoice
	{
		[Key]
		public int InvoiceId { get; set; }

		[ForeignKey("Customer")]
		public int CustomerId { get; set; }

		//[ForeignKey("ProdXInvoice")]
		//public int ProdXInvoiceId { get; set; }

		[Required]
		public DateTime PurchaseDate { get; set; }

		
		public virtual Customer Customer { get; set; }

		//public virtual IEnumerable<ProdXInvoice> ProdXInvoices { get; set; }
	}
}
