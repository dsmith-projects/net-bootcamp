using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using InventoryAppDB.Datos;
using InventoryAppDB.Logica;
using InventoryAppDB.Interfaz;
using Entities;

namespace InventoryAppDB.Interfaz
{
	class Program
	{
		static void Main(string[] args)
		{
			InputOutputData ioData = new InputOutputData();
			AuthenticateAdmin authAdmin = new AuthenticateAdmin();
			 

			// Verify if account is locked
			// if not locked do
			bool locked = false;

			if (!locked)
			{
				// Welcome the user 
				ioData.WelcomeUser();

				if (args.Length == 0)
				{
					ioData.LoginMessageUser();
					ioData.DisplayUserMenu();
					int option = ioData.ChooseAnOption();
					Console.WriteLine("Option chosen is {0}", option);

					switch (option)
					{
						case 1:
							ListInventoryItems();
							break;
						case 2:
							//AddNewProduct();
							break;
						case 3:
							//ModifyProductAvailableSupplies();
							break;
						default:
							break;
					}
				}
				else if (args.Length == 1)
				{
					Console.WriteLine("1 argument: admin");
				}
				else
				{
					Console.WriteLine("Else de los argumentos");
				}
			}

			Console.ReadKey();
		}


		public static void ListInventoryItems()
		{
			InventoryLogic inventoryLogic = new InventoryLogic();
			List<Product> listProducts = inventoryLogic.ListInventoryItems().ToList();

			foreach (var item in listProducts)
			{
				Console.WriteLine($"{item.ProductId} - {item.ProductName}");
			}
		}		

		//public static void AddNewProduct()
		//{
		//	Console.WriteLine("To do - Adding new product");

		//	using (var db = new InventoryDBContext())
		//	{
		//		var newProduct = new Product { Product_name = "cafe1820", Price = 1800, Avail_quantity = 250, Category = "Bebidas Calientes" };
		//		//var product2 = new Product { Product_name = "Leche Azul", Price = 800, Avail_quantity = 500, Category = "Lacteos" };
		//		//db.Products.Add(product1);
		//		//db.Products.Add(product2);
		//		//db.SaveChanges();

		//		Console.Clear();

		//		var query = from prod in db.Products
		//					orderby prod.Product_name
		//					select prod;

		//		Console.WriteLine(">>> Products in inventory: \n");
		//		Console.WriteLine("PRODUCT ID" + "\t" + "NAME" + "\t\t\t" + "PRICE" + "\t\t" + "AVAILABLE SUPPLIES" + "\t" + "CATEGORY");

		//		foreach (var item in query)
		//		{
		//			Console.WriteLine(item.Product_id + "\t\t" + item.Product_name + "\t\t" + item.Price + "\t\t" + item.Avail_quantity + "\t\t\t" + item.Category);
		//		}

		//		Console.WriteLine();
		//		Console.WriteLine("Press any key...");
		//	}
		//}

		//public static void ModifyProductAvailableSupplies()
		//{
		//	Console.WriteLine("To do - Modifying product # of supplies");
		//}

		//public static void ListAllUsers()
		//{
		//	using (var db = new InventoryDBContext())
		//	{
		//		//var cust1 = new Customer { First_name = "Juan", Last_name = "Perez", Telephone = "22556688", Email = "juan.perez@yahoo.com" };
		//		//var cust2 = new Customer { First_name = "Ana", Last_name = "Jimenez", Telephone = "88668800", Email = "ajimenez2000@gmail.com" };
		//		//db.Customers.Add(cust1);
		//		//db.Customers.Add(cust2);
		//		//db.SaveChanges();

		//		var query2 = from cust in db.Customers
		//					 select cust;

		//		Console.WriteLine("Customers in db: ");
		//		foreach (var item in query2)
		//		{
		//			Console.WriteLine("Customer name: " + item.First_name + " " + item.Last_name);
		//		}

		//		Console.WriteLine("Press any key...");
		//	}
		//}
	}	
}
