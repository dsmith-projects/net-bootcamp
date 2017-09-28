using System;
using System.Configuration;

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
                Console.WriteLine("BIENVENIDO(A)\n");

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
                            Console.WriteLine("Access denied. The application is locked. Contact your system administrator!");
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
                }
                else
                {
                    Console.WriteLine("Please try again! Make sure you start the app as a user or as the admin");
                }
            } else
            {
                Console.WriteLine("Access denied. The application is locked. Contact your system administrator!");
            }
            Console.ReadLine();
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

            if(numAttempt > MaxNumAttempts) {
                Console.WriteLine("Maximum number of attempts reached\nLocking your account. Contact your system administrator >> TODO");
            }

            return authenticated;
        }

        public static void RunAdminModule()
        {
            Console.Clear();

            string input = "";
            int option = 0;

            while (option != 5)
            {
                DisplayMenu();

				Console.Write("\nIngrese una opción: ");
				input = Console.ReadLine();
				bool result = Int32.TryParse(input, out option);

				if (result)
				{
					switch (option)
					{
						case 1:
							Console.WriteLine("LIST inventory items\nDisplays a list of all items in the inventory");
							break;
						case 2:
							Console.WriteLine("ADD a new item to inventory\nAllows you to create a new item and add it to the inventory");
							break;
						case 3:
							Console.WriteLine("MODIFY an item quantity\nLets you set the number of supplies for an item in the inventory");
							break;
						case 4:
							Console.WriteLine("REMOVE an item from inventory\nDeletes all supplies of that items from the inventory");
							break;
						case 5:
							Console.WriteLine("EXITING the application. Thank you!");
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

        public static void DisplayMenu() {
            Console.WriteLine("**** MAIN MENU ****");
            Console.WriteLine();
            Console.WriteLine("1. LIST inventory items");
            Console.WriteLine("2. ADD a new item to the inventory");
            Console.WriteLine("3. MODIFY the number of item supplies");
            Console.WriteLine("4. REMOVE an item from the inventory");
            Console.WriteLine("5. EXIT application");
        }

    }
}
