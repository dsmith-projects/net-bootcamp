﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryAppDB.View;
using InventoryAppDB.Model;

namespace InventoryAppDB.Controller
{
	class Program
	{
		static void Main(string[] args)
		{
			var view = new InventoryAppDB.View.InputOutputData();

			AuthenticateAdmin authAdmin = new AuthenticateAdmin();

			// Verify if account is locked
			// if not locked do
			bool locked = false;

			if(!locked)
			{
				// Welcome the user 
				view.WelcomeUser();

				if(args.Length == 0)
				{
					view.LoginMessage();
					view.DisplayUserMenu();
				}
			}

			using (var db = new InventoryDBContext())
			{
				var product1 = new Product { Product_name = "cafe1820", Price = 1800, Avail_quantity = 250, Category = "Bebidas Calientes" };
				var product2 = new Product { Product_name = "Leche Azul", Price = 800, Avail_quantity = 500, Category = "Lacteos" };
				db.Products.Add(product1);
				db.Products.Add(product2);
				db.SaveChanges();

				var query = from prod in db.Products
							orderby prod.Product_name
							select prod;

				Console.WriteLine("Products in db: ");
				foreach (var item in query)
				{
					Console.WriteLine(item.Product_name);
				}


				var cust1 = new Customer { First_name = "Juan", Last_name = "Perez", Telephone = "22556688", Email = "juan.perez@yahoo.com" };
				var cust2 = new Customer { First_name = "Ana", Last_name = "Jimenez", Telephone = "88668800", Email = "ajimenez2000@gmail.com" };
				db.Customers.Add(cust1);
				db.Customers.Add(cust2);
				db.SaveChanges();

				var query2 = from cust in db.Customers
							 select cust;

				Console.WriteLine("Customers in db: ");
				foreach (var item in query2)
				{
					Console.WriteLine("Customer name: " + item.First_name + " " + item.Last_name);
				}

				Console.WriteLine("Press any key...");
				Console.ReadLine();
			}
		}


	}
}
