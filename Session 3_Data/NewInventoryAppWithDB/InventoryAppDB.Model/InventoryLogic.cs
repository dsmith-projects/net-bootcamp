using Entities;
using InventoryAppDB.Datos;
using System;
using System.Collections.Generic;

namespace InventoryAppDB.Logica
{
    public class InventoryLogic
    {
		InventoryDAL datos = new InventoryDAL();

		public User RetrieveUser(string username, string password)
		{
			return datos.RetrieveUser(username, password);
		}

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

		public IEnumerable<Invoice> GetAllInvoices()
		{
			return datos.ListInvoices();
		}

		public IEnumerable<Invoice> GetInvoicesByCustomerId(int customerId)
		{
			return datos.GetInvoicesByCustomerId(customerId);
		}

		public void AddNewCategory(Category category)
		{
			datos.AddNewCategory(category);
		}

		public void EditCustomerInfo(int customerId, string firstName, string lastName, string telephone, string email)
		{
			datos.EditCustomerInfo(customerId, firstName, lastName, telephone, email);
			datos.RefreshAll();
		}

		public Customer RetrieveCustomerById(int customerId)
		{
			return datos.RetrieveCustomerById(customerId);
		}

		public Category GetFirstCategoryInserted()
		{
			Category firstCategory = datos.GetFirstCategoryInserted();
			return firstCategory;
		}		

		public Category GetLastCategoryInserted()
		{
			Category lastCategory = datos.GetLastCategoryInserted();
			return lastCategory;
		}

		public Product GetFirstProductInserted()
		{
			Product firstProduct = datos.GetFirstProductInserted();
			return firstProduct;
		}

		public Product GetLastProductInserted()
		{
			Product LastProduct = datos.GetLastProductInserted();
			return LastProduct;
		}

		public Customer GetFirstCustomerInserted()
		{
			Customer firstCustomer = datos.GetFirstCustomerInserted();
			return firstCustomer;
		}

		public Customer GetLastCustomerInserted()
		{
			Customer LastCustomer = datos.GetLastCustomerInserted();
			return LastCustomer;
		}

		public void ModifyProductAvailableSupplies(int productId, int quantity)
		{
			datos.ModifyProductAvailableSupplies(productId, quantity);
			datos.RefreshAll();
		}

		public decimal GetInvoicesGrandTotalByCustomerId(int customerId)
		{
			return datos.GetInvoicesGrandTotalByCustomerId(customerId);
		}

		public IEnumerable<TopThreeProd> GetTopThreePurchasedProducts(int customerId)
		{
			return datos.GetTopThreePurchasedProducts(customerId);
		}

		public decimal GetAverageSpentOnInvoice(int customerId)
		{
			return datos.GetAverageSpentOnInvoice(customerId);
		}

		public void RemoveProductById(int product_Id)
		{
			datos.RemoveProductById(product_Id);
		}

		public void RemoveCustomerById(int customer_Id)
		{
			datos.RemoveCustomerById(customer_Id);
		}

	}
}
