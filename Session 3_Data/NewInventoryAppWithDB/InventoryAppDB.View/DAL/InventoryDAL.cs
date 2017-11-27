using Entities;
using InventoryAppDB.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppDB.Datos
{
	public class InventoryDAL
	{
		public IEnumerable<Product> ListInventoryItems()
		{
			InventoryDBContext context = new InventoryDBContext();
			//context.Customers.Include(x => x.);
			return context.Products.ToList();
		}
	}
}
