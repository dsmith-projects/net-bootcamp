using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace InventoryApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			string defaultUsername = ConfigurationManager.AppSettings.Get("username");
            string defaultPassword = ConfigurationManager.AppSettings.Get("password");
            bool locked = Properties.Settings.Default.Locked;

            if (!locked)
            {
                //Console.WriteLine("Number of command line parameters = {0}", args.Length);
                Console.WriteLine("WELCOME TO THE INVENTORY PROGRAM\n");

                if (args.Length == 1)
                {
                    if (args[0].ToLower() == "admin")
                    {
                        //Console.WriteLine("Run app as admin");
                        bool authenticated = AuthenticateAdminUser();
                        //Console.WriteLine("authenticated: {0}", authenticated);
                        if (authenticated)
                        {
                            RunAdminModule();
                        }
                        else
                        {
                            Console.WriteLine("\nAccess denied!\nThe application was locked because you reached the maximum number of attempts to enter the correct username and password.\nContact your system administrator!");
							Properties.Settings.Default.Locked = true;
                            Properties.Settings.Default.Save();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please try again! Make sure you start the app as a user or as the admin");
                    }
                }
                else if (args.Length == 0)
                {
                    Console.WriteLine("Run app as user");
                    RunUserModule();
                }
                else
                {
                    Console.WriteLine("Please try again! Make sure you start the app as a user or as the admin");
                }
            } else
            {
                Console.WriteLine("Access denied. The application is locked due to too many attempts to enter an incorrect username or password. Contact your system administrator!");
            }
            //Console.ReadLine();
        }

        public static bool AuthenticateAdminUser() 
        {
            string username = "";
            string password = "";
			const string DefaultUsername = "hola";
			const string DefaultPassword = "mundo";

            const int MaxNumAttempts = 3;
            int numAttempt = 0;
            bool userVerified = false;
            bool authenticated = false;

            do
            {
                Console.Write("Please enter your username: ");
                username = Console.ReadLine();
                Console.Write("Please enter your password: ");
                password = Console.ReadLine();

                numAttempt++;
                //Console.WriteLine("Username: {0} - Password: {1}", username, password);
                //Console.WriteLine("DefaultUsername: {0} - DefaultPassword: {1}", DefaultUsername, DefaultPassword);
                if (username.Equals(DefaultUsername) && password.Equals(DefaultPassword))
                {
                    userVerified = true;
                    authenticated = true;
                }
                else 
                {
                    if (numAttempt < 3)
                    {
                        Console.WriteLine("Try again! Either the username or the password is incorrect. {0} attemps left", (MaxNumAttempts - numAttempt));
                    }
                }

                Console.WriteLine();
            } while (!userVerified && numAttempt < MaxNumAttempts);

            return authenticated;
        }

        public static void RunAdminModule()
        {
            Console.Clear();

            string input = "";
            int option = 0;
            int exitValue = 5;

			while (option != exitValue)
            {
                DisplayAdminMenu();

                Console.Write("\nChoose an option: ");
				input = Console.ReadLine();
				bool result = Int32.TryParse(input, out option);

				if (result)
				{
					switch (option)
					{
						case 1:
							//Console.WriteLine("LIST inventory items\nDisplays a list of all items in the inventory");
                            ListInventory(); // this method should receive the file containing the inventory as a parameter
							break;
						case 2:
                            Console.Clear();
							Console.WriteLine("ADDing a new item to inventory\n");
                            AddItemToInventory();
							break;
						case 3:
                            Console.Clear();
							Console.WriteLine("MODIFY an item quantity\nLets you set the number of supplies for an item in the inventory");
                            ModifyItemData();
							break;
						case 4:
							Console.WriteLine("REMOVE an item from inventory\nDeletes all supplies of that items from the inventory");
							break;
						case 5:
                            Console.Clear();
							Console.WriteLine("EXITING the application... Thank you!");
							break;
						case -1:
							Console.WriteLine("TODO");
							break;
						default:
							Console.WriteLine("TODO");
							break;
					}
				}
				else
				{
					Console.WriteLine("Invalid input. Please try again");
                }
            }

        }

        public static void DisplayAdminMenu() {
            Console.WriteLine("**** MAIN MENU ****");
            Console.WriteLine();
            Console.WriteLine("1. LIST inventory items");
            Console.WriteLine("2. ADD a new item to the inventory");
            Console.WriteLine("3. MODIFY the number of item supplies");
            Console.WriteLine("4. REMOVE an item from the inventory");
            Console.WriteLine("5. EXIT application");
        }


		public static void RunUserModule()
		{
			Console.Clear();

			string input = "";
			int option = 0;
            int exitValue = 4;

			while (option != exitValue)
			{
				DisplayUserMenu();

				Console.Write("\nIngrese una opción: ");
				input = Console.ReadLine();
				bool result = Int32.TryParse(input, out option);

				if (result)
				{
					switch (option)
					{
						case 1:
							//Console.WriteLine("LIST inventory items\n");
                            ListInventory();
							break;
						case 2:
							Console.WriteLine("CREATE new invoice\n");
							break;
						case 3:
							Console.WriteLine("DISPLAY invoice\n");
							break;
						case 4:
							Console.Clear();
							Console.WriteLine("EXITING the application... Thank you!");
							break;
						case -1:
							Console.WriteLine("TODO");
							break;
						default:
							Console.WriteLine("TODO");
							break;
					}
				}
				else
				{
					Console.WriteLine("Invalid input. Please try again");
				}
			}

		}

		public static void DisplayUserMenu()
		{
			Console.WriteLine("**** MAIN MENU ****");
			Console.WriteLine();
			Console.WriteLine("1. LIST inventory items");
			Console.WriteLine("2. CREATE new invoice");
			Console.WriteLine("3. DISPLAY invoice");
			Console.WriteLine("4. EXIT application");
		}

        public static void ListInventory() 
        {
            Console.Clear();
            string path = @AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";

			if (!File.Exists(path))
			{
                Console.WriteLine("Inventory file does not exist.\nCreating a new empty inventory file.\nHit enter to continue.");
                string[] fileHeader = { "PRODUCT_ID,NAME,COST,QUANTITY" };
				File.WriteAllLines(path, fileHeader);
			} else
            {
                try
                {
                    string[] lines = File.ReadAllLines(path);

                    if (lines.Length > 0)
                    {
                        foreach (string line in lines)
                        {
                            string[] lineDetails = line.Split(',');
                            foreach (var item in lineDetails)
                            {
                                Console.Write(item + "\t\t\t");
                            }
                            Console.WriteLine();
                        }
                    } else
                    {
                        Console.WriteLine("Nothing to display. Empty inventory file.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("The file could not be read. Please try again.");
                }
            }

            Console.ReadLine();
			Console.Clear();
        }

        public static void AddItemToInventory() 
        {
            string inventoryFilePath = AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";

            string productId = "";
            string productName = "";
            decimal cost = 0;
            int quantity = 0;

            Console.WriteLine("*** NEW ITEM ***");
            Console.WriteLine();
            Console.WriteLine("Provide data for the new item: ");
            Console.WriteLine();
            Console.Write(">> Product ID: ");
            productId = Console.ReadLine();
            Console.Write(">> Name: ");
            productName = Console.ReadLine();
            cost = RequestProductCost();
            quantity = RequestProductQuantity();

            // I must include a try/catch block for the following section
            StringBuilder newLine = new StringBuilder();
			newLine.AppendLine(productId + "," + productName + "," + cost + "," + quantity);
            File.AppendAllText(inventoryFilePath, newLine.ToString());
            Console.Clear();
            Console.WriteLine(">>> Product item SUCCESSFULLY added to the inventory\n");
        }

        public static int RequestProductQuantity() {
            int quantity = 0;
            bool converted = false;

            do
            {
                Console.Write(">> Available Quantity: ");
                string quantityValue = Console.ReadLine();
				converted = Int32.TryParse(quantityValue, out quantity);
                if (!converted)
                {
                    Console.WriteLine("\nIncorrect value. Please try again! \n>>>Quantity values can only be positive or negative integers");
                }
            } while (!converted);
            return quantity;
        }

		public static decimal RequestProductCost()
		{
            decimal cost = 0;
			bool converted = false;

			do
			{
				Console.Write(">> Cost: ");
				string costValue = Console.ReadLine();
                converted = Decimal.TryParse(costValue, out cost);
				if (!converted)
				{
					Console.WriteLine("\nIncorrect value. Please try again! ");
				}
			} while (!converted);
			return cost;
		}

        public static void ModifyItemData() 
        {
            string productId = "";
            string quantityValue = "";
            int quantity = 0;
            bool converted = false;
            bool productFound = false;

            string path = @AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";

			if (!File.Exists(path))
			{
				Console.WriteLine("Inventory file does not exist.\nTo create a new file choose option 1 from the menu.");
			} else
            {		
                try
                {
                    string[] lines = File.ReadAllLines(path);

                    if (lines.Length > 0) {
						// verificar si producto existe en el inventario	

						Console.WriteLine("Please provide the following data: \n");
						Console.Write(">> Product ID: ");
						productId = Console.ReadLine();

                        for (int i = 0; i < lines.Length; i++)
                        {
                            string line = lines[i];
							string[] lineDetails = line.Split(',');

							if (lineDetails[0] == productId)
							{
								do
								{
									Console.Write(">> Quantity: ");
									quantityValue = Console.ReadLine();
									converted = Int32.TryParse(quantityValue, out quantity);
									if (!converted)
									{
										Console.WriteLine("\nIncorrect value. Please try again! ");
									}
								} while (!converted);

                                string newLine = productId + "," + lineDetails[1] + "," + lineDetails[2] + "," + quantityValue;
                                lines[i] = newLine;

                                productFound = true;
                                break;
							} 
                        }

                        if (productFound)
                        {
                            File.WriteAllLines(path, lines);
                        } else
                        {
                            Console.WriteLine("The product id you provided did not match any products in the inventory.");
                        }
                    }


                }
                catch (Exception)
                {
                    Console.WriteLine("The file could not be read. Please try again.");
                }
            }
			
        }
    }
}
