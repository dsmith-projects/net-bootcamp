using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppDB.Interfaz
{
    public class InputOutputData
    {
		public void WelcomeUser()
		{
			Console.WriteLine("WELCOME TO THE INVENTORY PROGRAM\n");
		}

		public void LoginMessageUser()
		{
			Console.WriteLine("You have signed in as USER\n");
		}
		public void DisplayUserMenu()
		{
			Console.WriteLine("**** MAIN MENU *****");
			Console.WriteLine();
			Console.WriteLine("1. LIST inventory items");
			Console.WriteLine("2. CREATE new invoice");
			Console.WriteLine("3. DISPLAY invoices report");
			Console.WriteLine("4. EXIT application");
			Console.WriteLine();
		}
		public int ChooseAnOption()
		{
			int option = 0;
			string input;
			bool isNumber;
			bool repeatMenu = false;

			do
			{
				Console.Write("Choose an option: ");
				input = Console.ReadLine();
				isNumber = Int32.TryParse(input, out option);
				if (!isNumber)
				{
					Console.WriteLine(">>> Invalid input. Please try again!\n");
					repeatMenu = true;
				}
				if (option < 1 || option > 4)
				{
					Console.WriteLine(">>> Option not available. Please try again!\n");
					repeatMenu = true;
				}
			} while (repeatMenu);

			return option;
		}

		//public Product CreateNewProduct()
		//{
		//	string product_name = "";
		//	decimal price = 0;
		//	int quantity = 0;
		//	string category = "";

		//	bool convertedToDecimal;
		//	bool convertedToInteger;

		//	Console.WriteLine("Please provide the following information:\n");

		//	Console.Write("Product name: ");
		//	product_name = Console.ReadLine();

		//	do
		//	{
		//		Console.Write("Price: ");
		//		convertedToDecimal = Decimal.TryParse(Console.ReadLine(), out price);

		//		if (!convertedToDecimal)
		//		{
		//			Console.WriteLine(">>> Incorrect value. Please try again:\n");
		//		}
		//	} while (!convertedToDecimal);

		//	do
		//	{
		//		Console.Write("Quantity: ");
		//		convertedToInteger = Int32.TryParse(Console.ReadLine(), out quantity);

		//		if (!convertedToInteger)
		//		{
		//			Console.WriteLine(">>> Incorrect value. Please try again:\n");
		//		}
		//	} while (!convertedToInteger);

		//	Console.Write("Category: ");
		//	category = Console.ReadLine();

		//	Product newProduct = new Product
		//	{
		//		Product_name = product_name,
		//		Price = price,
		//		Avail_quantity = quantity,
		//		Category = category
		//	};

		//	return newProduct;
		//}

	}
}
