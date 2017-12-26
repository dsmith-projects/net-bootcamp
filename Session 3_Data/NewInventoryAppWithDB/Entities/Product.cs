
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }

		[Required]
		[StringLength(128)]
		public string ProductName { get; set; }

		[Required]
		public decimal Price { get; set; }

		[Required]
		public int AvailQuantity { get; set; }
		
		[ForeignKey("Category")]
		public int CategoryId { get; set; }

		public virtual Category Category { get; set; }

		public bool ActiveProduct { get; set; }

	}
}
