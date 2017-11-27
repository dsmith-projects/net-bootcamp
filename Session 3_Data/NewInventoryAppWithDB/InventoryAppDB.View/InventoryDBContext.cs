using Entities;
using System.Data.Entity;

namespace InventoryAppDB.Datos
{
	public class InventoryDBContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<ProdXInvoice> ProdXInvoice { get; set; }
	}
}
