using Entities;
using InventoryAppDB.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppDB.Datos
{
	public class InventoryDAL
	{
		InventoryDBContext context = new InventoryDBContext();

		public IEnumerable<Product> ListInventoryItems()
		{
			//InventoryDBContext context = new InventoryDBContext();
			//context.Customers.Include(x => x.);
			return context.Products.ToList();
		}

		public IEnumerable<Customer> ListCustomers()
		{			
			return context.Customers.ToList();
		}

		public IEnumerable<Category> ListCategories()
		{
			return context.Categories.ToList();
		}

		public IEnumerable<User> ListUsers()
		{
			return context.Users.ToList();
		}

		public IEnumerable<Invoice> ListInvoices()
		{
			return context.Invoices.ToList();
		}

		public IEnumerable<ProdXInvoice> ListProdXInvoices()
		{
			return context.ProdXInvoice.ToList();
		}

		public List<UserNameIsAdminBDSet> VerifyIfUserIsAdmin(string userName)
		{
			SqlParameter param = new SqlParameter("@UserName", userName);
			var sqlResult = context.Database.SqlQuery<UserNameIsAdminBDSet>("sp_Users_VerifyIfUserIsAdmin @UserName", param).ToList();

			return sqlResult.ToList();
		}

		public void AddNewProduct(Product product)
		{
			context.Products.Add(product);
			context.SaveChanges();
		}

		public void AddNewCustomer(Customer customer)
		{
			context.Customers.Add(customer);
			context.SaveChanges();
		}

		public void AddNewInvoice(Invoice invoice)
		{
			context.Invoices.Add(invoice);
			context.SaveChanges();
		}

		public Invoice GetLastInvoiceInserted()
		{
			Invoice lastInvoice = context.Invoices.ToList().LastOrDefault();

			return lastInvoice;
		}

		public void AddProductsToInvoice(ProdXInvoice prod)
		{
			context.ProdXInvoice.Add(prod);
			context.SaveChanges();
		}

		//public List<Invoice> GetInvoicesWithinDatesRange(DateTime startDate, DateTime endDate)
		//{			
		//	SqlParameter start = new SqlParameter("@PurchaseDate");
		//	List<Invoice> invoicesWithinRange = await context
		//}

	}
}
