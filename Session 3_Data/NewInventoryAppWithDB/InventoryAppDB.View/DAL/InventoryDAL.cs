﻿using Entities;
using InventoryAppDB.Datos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace InventoryAppDB.Datos
{
	public class InventoryDAL
	{
		InventoryDBContext context = new InventoryDBContext();

		public User RetrieveUser(string username, string password)
		{
			//var user =
			//	from c in context.Users
			//	where c.Name == username
			//	where c.Password == password
			//	select c;
			//return user;

			SqlParameter p_user = new SqlParameter("@Name", username);
			SqlParameter p_password = new SqlParameter("@Password", password);

			var sqlResult = context.Database.SqlQuery<User>("sp_Users_RetrieveUser @Name, @Password", p_user, p_password).SingleOrDefault();

			return sqlResult;
		}

		

		public IEnumerable<Product> ListInventoryItems()
		{
			//IEnumerable<Product> listActiveProducts = context.Products.ToList();
			
			var activeProducts = 
				from c in context.Products
				where c.ActiveProduct == true
				select c;
			return activeProducts;
			//return context.Products.ToList();
		}

		public IEnumerable<Customer> ListCustomers()
		{
			var activeCustomers =
				from c in context.Customers
				where c.ActiveCustomer == true
				select c;
			return activeCustomers;
			//return context.Customers.ToList();
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

		public IEnumerable<Invoice> GetInvoicesWithinDateRange(DateTime startDate, DateTime endDate)
		{
			SqlParameter p_startDate = new SqlParameter("@startDate", startDate);
			SqlParameter p_endDate = new SqlParameter("@endDate", endDate);

			var sqlResult = context.Database.SqlQuery<Invoice>("sp_Invoices_GetInvoicesWithinDateRange @startDate, @endDate", p_startDate, p_endDate);
			
			return sqlResult.ToList();
		}

		public IEnumerable<Invoice> GetInvoicesByCustomerId(int customerId)
		{
			SqlParameter p_customerId = new SqlParameter("@customerId", customerId);

			var sqlResult = context.Database.SqlQuery<Invoice>("sp_Invoices_GetInvoicesByCustomerId @customerId", p_customerId);

			return sqlResult.ToList();
		}

		public void AddNewCategory(Category category)
		{
			context.Categories.Add(category);
			context.SaveChanges();
		}

		public Category GetLastCategoryInserted()
		{
			Category lastCategory = context.Categories.ToList().LastOrDefault();
			return lastCategory;
		}

		public Category GetFirstCategoryInserted()
		{
			Category firstCategory = context.Categories.ToList().FirstOrDefault();
			return firstCategory;
		}

		public Product GetLastProductInserted()
		{
			Product lastProduct = context.Products.ToList().LastOrDefault();
			return lastProduct;
		}

		public Product GetFirstProductInserted()
		{
			Product firstProduct = context.Products.ToList().FirstOrDefault();
			return firstProduct;
		}

		public Customer GetLastCustomerInserted()
		{
			Customer lastCustomer = context.Customers.ToList().LastOrDefault();
			return lastCustomer;
		}

		public Customer GetFirstCustomerInserted()
		{
			Customer firstCustomer = context.Customers.ToList().FirstOrDefault();
			return firstCustomer;
		}

		public Customer RetrieveCustomerById(int customerId)
		{
			SqlParameter p_customerId = new SqlParameter("@customerId", customerId);

			var sqlResult = context.Customers.SqlQuery("sp_Customers_RetrieveCustomerById @customerId", p_customerId).SingleOrDefault();

			return sqlResult;
		}

		public void EditCustomerInfo(int customerId, string firstName, string lastName, string telephone, string email)
		{
			SqlParameter p_customerId = new SqlParameter("@customerId", customerId);
			SqlParameter p_firstName = new SqlParameter("@firstName", firstName);
			SqlParameter p_lastName = new SqlParameter("@lastName", lastName);
			SqlParameter p_telephone = new SqlParameter("@telephone", telephone);
			SqlParameter p_email = new SqlParameter("@email", email);

			context.Database.ExecuteSqlCommand("sp_Customers_UpdateCustomerInformation @customerId, @firstName, @lastName, @telephone, @email", p_customerId, p_firstName, p_lastName, p_telephone, p_email);
			context.SaveChanges();
		}	
		
		public void RefreshAll()
		{
			foreach (var entity in context.ChangeTracker.Entries())
			{
				entity.Reload();
			}
		}

		public void ModifyProductAvailableSupplies(int productId, int quantity)
		{
			SqlParameter p_productId = new SqlParameter("@productId", productId);
			SqlParameter p_quantity = new SqlParameter("@availQuantity", quantity);

			context.Database.ExecuteSqlCommand("sp_Products_UpdateNumberSupplies @productId, @availQuantity", p_productId, p_quantity);
			context.SaveChanges();
		}

		public decimal GetInvoicesGrandTotalByCustomerId(int customerId)
		{
			SqlParameter p_customerId = new SqlParameter("@customerId", customerId);

			decimal sqlResult = context.Database.SqlQuery<decimal>("sp_Reports_SumOfTotalsFromCustomerInvoices @customerId", p_customerId).Single();

			return sqlResult;
		}

		public IEnumerable<TopThreeProd> GetTopThreePurchasedProducts(int customerId)
		{
			SqlParameter p_customerId = new SqlParameter("@CustomerId", customerId);

			var sqlResult = context.Database.SqlQuery<TopThreeProd>("sp_Reports_Top3ProductsPurchasedByCustomer @CustomerId", p_customerId);

			return sqlResult.ToList();
		}

		public decimal GetAverageSpentOnInvoice(int customerId)
		{
			SqlParameter p_customerId = new SqlParameter("@CustomerId", customerId);

			decimal average = context.Database.SqlQuery<decimal>("sp_Reports_AverageSpentOnInvoicesByCustomer2 @CustomerId", p_customerId).Single();

			return average;
		}

		public void RemoveProductById(int product_Id)
		{
			SqlParameter p_productId = new SqlParameter("@ProductId", product_Id);

			context.Database.ExecuteSqlCommand("sp_Products_DeactivateProduct @ProductId", p_productId);
			context.SaveChanges();
		}

		public void RemoveCustomerById(int customer_Id)
		{
			SqlParameter p_customerId = new SqlParameter("@CustomerId", customer_Id);

			context.Database.ExecuteSqlCommand("sp_Customers_DeactivateCustomer @CustomerId", p_customerId);
			context.SaveChanges();
		}
	}
}
