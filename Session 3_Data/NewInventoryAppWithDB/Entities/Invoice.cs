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

	public class TopThreeProd
	{		
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Total_Quantity { get; set; }
		public string Name { get; set; }
	}

	//public class SumOfInvoicesTotals
	//{
	//	public decimal Total { get; set; }
	//}

	//public class AverageSpentOnInvoices
	//{
	//	public decimal Average { get; set; }
	//}
}
