using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppDB.View
{
    public class InputOutputData
    {
		public void WelcomeUser()
		{
			Console.WriteLine("WELCOME TO THE INVENTORY PROGRAM\n");
		}

		public void LoginMessage()
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

			Console.WriteLine("Choose an option: ");
			input = Console.ReadLine();
			isNumber = Int32.TryParse(input, out option);



			return option;
		}

    }
}
