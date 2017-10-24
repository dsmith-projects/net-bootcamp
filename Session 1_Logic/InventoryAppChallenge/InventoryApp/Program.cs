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
            AuthenticateAdmin authAdmin = new AuthenticateAdmin();
            AdminModule adminModule = new AdminModule();
            UserModule userModule = new UserModule();

            // Variable that verifies whether the app has been locked after multiple attempts with the wrong credentials
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
                        bool authenticated = authAdmin.AuthenticateAdminUser();
                        //Console.WriteLine("authenticated: {0}", authenticated);
                        if (authenticated)
                        {
                            adminModule.RunAdminModule();
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
                    userModule.RunUserModule();
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

	}
}
