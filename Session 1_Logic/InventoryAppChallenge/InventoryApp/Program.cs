using System;
using System.Configuration;
using System.IO;
using System.Text;
using InventoryApp.FileHandler;

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
            }
            else
            {
                Console.WriteLine("Access denied. The application is locked due to too many attempts to enter an incorrect username or password. Contact your system administrator!");
            }
            //Console.ReadLine();
        }

        public static bool AuthenticateAdminUser()
        {
            string username = "";
            string password = "";
            //const string DefaultUsername = "hola";
            //const string DefaultPassword = "mundo";

            string defaultUsername = ConfigurationManager.AppSettings.Get("username");
            string defaultPassword = ConfigurationManager.AppSettings.Get("password");

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
                if (username.Equals(defaultUsername) && password.Equals(defaultPassword))
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
                            Console.Clear();
                            ReadWriteFiles.ListInventory();
                            break;
                        case 2:
                            Console.Clear();
                            //Console.WriteLine("ADDing a new item to inventory\n");
                            ReadWriteFiles.AddItemToInventory();
                            break;
                        case 3:
                            Console.Clear();
                            //Console.WriteLine("MODIFY an item quantity\n");
                            ReadWriteFiles.ModifyItemData();
                            break;
                        case 4:
                            Console.Clear();
                            //Console.WriteLine("REMOVE an item from inventory\nDeletes all supplies of that items from the inventory");
                            ReadWriteFiles.RemoveItemFromInventory();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("EXITING the application... Thank you!");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine(">>> Invalid number. Please try again!\n");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">>> Invalid input. Please try again!\n");
                }
            }

        }

        public static void DisplayAdminMenu()
        {
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
            int counter = 1000;
            decimal grandTotal = 0;

            while (option != exitValue)
            {
                DisplayUserMenu();

                Console.Write("\nChoose an option: ");
                input = Console.ReadLine();
                bool result = Int32.TryParse(input, out option);

                if (result)
                {
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            ReadWriteFiles.ListInventory();
                            break;
                        case 2:
                            //Console.WriteLine("CREATE new invoice\n");
                            Console.Clear();
                            grandTotal += ReadWriteFiles.CreateNewInvoice(counter++);
                            break;
                        case 3:
                            //Console.WriteLine("DISPLAY invoice\n");
                            Console.Clear();
                            DisplayInvoicesReport(grandTotal, (counter - 1000));
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("EXITING the application... Thank you!");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine(">>> Invalid input. Please try again!\n");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">>> Invalid input. Please try again!\n");
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
                        
        public static void DisplayInvoicesReport(decimal grandTotal, int invoicesCounter)
        {
            Console.Clear();
            Console.WriteLine("Number of invoices created: {0}", invoicesCounter);
            Console.WriteLine("Grand total for all invoices: {0}", grandTotal);
            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
            Console.Clear();
        }

	}
}
