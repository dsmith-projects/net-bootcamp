﻿using System;
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

			const int LAST_MENU_OPTION_ADMIN = 8;
			const int LAST_MENU_OPTION_USER = 5;

			// Verify if account is locked
			// if not locked do
			bool locked = false;
			bool salir = false;
			int option = 0;

			if (!locked)
			{
				// Welcome the user 
				ioData.WelcomeUser();

				if (args.Length == 0)
				{
					ioData.LoginMessageUser();

					do
					{
						ioData.DisplayUserMenu();
						option = ioData.ChooseAnOption(LAST_MENU_OPTION_USER);
						//Console.WriteLine("Option chosen is {0}", option);

						int customerId = -1;
						int productId = -1;
						int quantityRequested = 0;
						string startDate = "";
						string endDate = "";
						string purchaseDate = "";

						switch (option)
						{
							case 1:
								ioData.DisplayMessageToListProductsInInventory();
								ioData.ListInventoryItems();
								ioData.PressAnyKeyToContinue();
								break;
							case 2:
								ioData.DisplayMessageToCreateNewInvoice();								
								ioData.DisplayCustomers();
								customerId = ioData.DisplayMessageToChooseCustomer();							
								Invoice newInvoice = ioData.CreateNewInvoice(customerId);
								//ioData.DisplayMessageToChooseProducts();
								ioData.AddNewInvoice(newInvoice);
								ioData.AddProductsToInvoice();
								ioData.PressAnyKeyToContinue();
								break;
							case 3:
								ioData.DisplayMessageToGenerateInvoicesReportByDates();
								startDate = ioData.RequestDate("Please provide start date. ");
								endDate = ioData.RequestDate("Please provide end date. ");
								ioData.GenerateInvoiceReportFromDatesRange(startDate, endDate);
								ioData.PressAnyKeyToContinue();
								break;
							case 4:
								ioData.DisplayMessageToGenerateInvoicesReportByCustomerId();
								ioData.DisplayCustomers();
								customerId = ioData.DisplayMessageToChooseCustomer();
								ioData.PressAnyKeyToContinue();
								break;
							default:
								salir = true;
								ioData.DisplayExitMessage();
								break;
						} 
					} while (!salir);
				}
				else if (args.Length == 1)
				{
					if (args[0].ToLower() == "admin")
					{
						ioData.LoginMessageAdmin();

						do
						{
							//Console.WriteLine("1 argument: admin");							
							ioData.DisplayAdminMenu();
							option = ioData.ChooseAnOption(LAST_MENU_OPTION_ADMIN);

							int customerId = -1;
							int productId = -1;

							switch (option)
							{
								case 1:
									ioData.DisplayMessageToListProductsInInventory();
									ioData.ListInventoryItems();
									ioData.PressAnyKeyToContinue();
									break;
								case 2:
									ioData.DisplayMessageToAddNewProduct();
									Product newProduct = ioData.CreateNewProduct();
									ioData.AddNewProduct(newProduct);
									ioData.PressAnyKeyToContinue();
									break;
								case 3:
									ioData.DisplayMessageToEditProductSupplies();									
									ioData.ListInventoryItems();
									productId = ioData.DisplayMessageToChooseProduct();
									ioData.ModifyProductAvailableSupplies(productId);
									ioData.PressAnyKeyToContinue();
									break;
								case 4:
									// Remove product from inventory
									// Que pasa si se queire eliminar un producto que ya esta en un invoice
									ioData.DisplayMessageToDeleteProduct();
									ioData.ListInventoryItems();
									productId = ioData.DisplayMessageToChooseProduct();
									ioData.RemoveProductById(productId);
									ioData.PressAnyKeyToContinue();
									break;
								case 5:
									ioData.DisplayMessageToAddNewCustomer();
									Customer newCustomer = ioData.CreateNewCustomer();
									ioData.AddNewCustomer(newCustomer);
									ioData.PressAnyKeyToContinue();
									break;
								case 6:
									ioData.DisplayMessageToEditCustomer();
									ioData.DisplayCustomers();
									customerId = ioData.DisplayMessageToChooseCustomer();
									ioData.EditCustomerInfo(customerId);
									ioData.PressAnyKeyToContinue();
									break;
								case 7:
									ioData.DisplayMessageToDeleteCustomer();
									ioData.DisplayCustomers();
									customerId = ioData.DisplayMessageToChooseCustomer();
									ioData.RemoveCustomerById(customerId);
									ioData.PressAnyKeyToContinue();
									break;
								default:
									salir = true;
									ioData.DisplayExitMessage();
									break;
							} 
						} while (!salir);
					}
					else
					{
						ioData.DisplayInitializationParameterError();
					}
				}
				else
				{
					ioData.DisplayInitializationParameterError();
				}
			}

			Console.ReadKey();
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

		


	}	
}