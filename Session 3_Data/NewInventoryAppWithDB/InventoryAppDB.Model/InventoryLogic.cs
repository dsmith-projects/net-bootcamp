using Entities;
using InventoryAppDB.Datos;
using System.Collections.Generic;

namespace InventoryAppDB.Logica
{
    public class InventoryLogic
    {
		public IEnumerable<Product> ListInventoryItems()
		{
			InventoryDAL datos = new InventoryDAL();
			return datos.ListInventoryItems();
		}

		//public IEnumerable<Customer> ListInventoryItems()
		//{
		//	InventoryDAL datos = new InventoryDAL();
		//	return datos.ListInventoryItems();
		//}
	}
}
