using Entities;
using InventoryAppDB.Datos;
using System;
using System.Collections.Generic;

namespace InventoryAppDB.Logica
{
    public class InventoryLogic
    {
		InventoryDAL datos = new InventoryDAL();

		public IEnumerable<Product> ListInventoryItems()
		{
			//InventoryDAL datos = new InventoryDAL();
			return datos.ListInventoryItems();
		}

		public IEnumerable<Customer> ListCustomers()
		{			
			return datos.ListCustomers();
		}
				
		public IEnumerable<Category> ListCategories()
		{
			return datos.ListCategories();
		}

		public IEnumerable<User> ListUsers()
		{
			return datos.ListUsers();
		}

		public IEnumerable<Invoice> ListInvoices()
		{
			return datos.ListInvoices();
		}

		public IEnumerable<ProdXInvoice> ListProdXInvoices()
		{
			return datos.ListProdXInvoices();
		}

		public List<UserNameIsAdminBDSet> VerifyIfUserIsAdmin(string userName)
		{
			var result = datos.VerifyIfUserIsAdmin(userName);
			return result;
		}

		public void AddNewProduct(Product product)
		{
			datos.AddNewProduct(product);
		}

		public void AddNewCustomer(Customer customer)
		{
			datos.AddNewCustomer(customer);
		}

		public void AddNewInvoice(Invoice invoice)
		{
			datos.AddNewInvoice(invoice);
		}

		public Invoice GetLastInvoiceInserted()
		{
			Invoice lastInvoice = datos.GetLastInvoiceInserted();
		
			return lastInvoice;
		}

		public void AddProductsToInvoice(List<ProdXInvoice> listOfProdXInvoices)
		{
			foreach (var prod in listOfProdXInvoices)
			{
				datos.AddProductsToInvoice(prod);
			}
		}

		public IEnumerable<Invoice> GetInvoicesWithinDateRange(DateTime startDate, DateTime endDate)
		{
			return datos.GetInvoicesWithinDateRange(startDate, endDate);
		}

		public IEnumerable<Invoice> GetInvoicesByCustomerId(int customerId)
		{
			return datos.GetInvoicesByCustomerId(customerId);
		}
	}
}
