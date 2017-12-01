using Entities;
using InventoryAppDB.Datos;
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
	}
}
